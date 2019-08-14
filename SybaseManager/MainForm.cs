using Dapper;
using SybaseManager.Core.Factories;
using SybaseManager.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SybaseManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            connectionsTreeView.Nodes.Add("Connections");
        }

        private void ConnectionsTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var selectedNode = connectionsTreeView.SelectedNode;

            if (selectedNode.Tag == null || !selectedNode.Tag.Equals("Table")) return;

            dataGridView1.Columns.Clear();
            var data =
                CurrentInformation.ConnectionProperties.Connection.Query<object>($"select * from {selectedNode.Text}");
            var columns = CurrentInformation.ConnectionProperties.Connection.Query<string>(
                $@"SELECT syscolumns.name FROM sysobjects 
                                                                                                JOIN syscolumns ON sysobjects.id = syscolumns.id
                                                                                                WHERE sysobjects.name LIKE '{selectedNode.Text}'");

            foreach (var column in columns)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = column,
                    HeaderText = column,
                    Name = column
                });
            }

            dataGridView1.DataSource = data;
        }

        private void ConnectionsTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            var node = connectionsTreeView.GetNodeAt(e.X, e.Y);
            connectionsTreeView.SelectedNode = node;

            if (node?.Tag == null) return;

            CurrentInformation.ObjectType = node.Tag.ToString();
            CurrentInformation.ObjectName = node.Text;
            treeContextMenuStrip.Show(connectionsTreeView, new Point(e.X, e.Y));
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            const string sqlGenTable = @"
                        DECLARE @TableName               varchar(50)
                        DECLARE @ObjectID                int
                        DECLARE @IndexID                 int
                        DECLARE @IndexStatus             int
                        DECLARE @IndexName               varchar(30)
                        DECLARE @msg                     varchar(255)
                        DECLARE @OnlyTableName           varchar(50)
                        DECLARE @LastColumnId            int
                        DECLARE @i                       int

                        SELECT @OnlyTableName = 'Customers'

                        CREATE TABLE #columns (
                            column_name char(30)    NULL,
                            type_name   char(30)    NULL,
                            length      char(10)    NULL,
                            iden_flag   char(10)    NULL,
                            null_flag   char(20)    NULL,
                            flag        char(1)     NULL
                        )

                        CREATE TABLE #rtn (
                            msg   varchar(255)   NULL
                        )



                        SELECT @TableName = name,
                                @ObjectID  = id
                            FROM sysobjects
                        WHERE type = 'U'
                            AND name = @OnlyTableName
                        ORDER BY name

                        SELECT @LastColumnId = MAX(colid) FROM syscolumns WHERE id = @ObjectID

                        INSERT #columns
                        SELECT col.name,
                                typ.name,
                                CASE WHEN typ.name in ('decimal','numeric') THEN '(' +
                    convert(varchar, col.prec) + ',' + convert(varchar, col.scale) + ')'
                                    WHEN typ.name like '%char%'THEN
                    '('+CONVERT(varchar,col.length)+')'
                                    ELSE '' END,
                                CASE WHEN col.status = 0x80 THEN 'IDENTITY' ELSE '' END,
                                CASE WHEN convert(bit, (col.status & 8)) = 0 THEN 'NOT NULL'
                    ELSE 'NULL' END + CASE WHEN col.colid = @LastColumnId THEN ')' ELSE
                    ',' END,
                                NULL
                            FROM syscolumns col, systypes typ
                        WHERE col.id = @ObjectID
                            AND col.usertype = typ.usertype
                        ORDER BY col.colid


                        INSERT #rtn
                        SELECT 'CREATE TABLE ' + @TableName + ' ('
                        UNION ALL
                        SELECT '    '+
                                        column_name + replicate(' ',30- len(column_name)) +
                                        type_name + length + replicate(' ',20 -
                    len(type_name+length)) +
                                        iden_flag + replicate(' ',10 - len(iden_flag))+
                                        null_flag
                            FROM #columns

                        SELECT name, indid, status, 'N' as flag INTO #indexes
                        FROM sysindexes WHERE id = @ObjectID

                        SET ROWCOUNT 1
                        WHILE 1=1
                        BEGIN
                            SELECT @IndexName = name, @IndexID = indid, @IndexStatus =
                    status FROM #indexes WHERE flag = 'N'
                            IF @@ROWCOUNT = 0
                                BREAK

                            SELECT @i = 1
                            SELECT @msg = ''
                            WHILE 1=1
                            BEGIN
                                IF index_col(@TableName, @IndexID, @i) IS NULL
                                BREAK

                                SELECT @msg = @msg + index_col(@TableName, @IndexID, @i) +
                    CASE WHEN index_col(@TableName, @IndexID, @i+1) IS NOT NULL THEN ','
                    END
                                SELECT @i = @i+1
                            END

                            IF @IndexStatus & 2048 = 2048 --PRIMARY KEY
                                INSERT #rtn
                                SELECT 'ALTER TABLE ' + @TableName +
                                    ' ADD CONSTRAINT ' + @IndexName +
                                    ' primary key '+
                                    CASE WHEN @IndexID != 1 THEN 'nonclustered ' END +
                    '('+ @msg +')'
                            ELSE
                                IF (@IndexStatus & 2048 = 0 AND @IndexID NOT IN (0, 255))
                    --NOT PRIMARY KEY
                                INSERT #rtn
                                SELECT 'CREATE '+
                                CASE WHEN @IndexStatus & 2 = 2 THEN 'UNIQUE ' ELSE '' END +
                                CASE WHEN @IndexID = 1 THEN 'CLUSTERED ' ELSE 'NONCLUSTERED ' END +
                                'INDEX ' + @IndexName + ' ON ' + @TableName + ' ('+ @msg +')'

                            UPDATE #indexes SET flag = 'Y' WHERE indid = @IndexID

                        END
                        SET ROWCOUNT 0

                        SELECT * FROM #rtn

                        DROP TABLE #columns
                        DROP TABLE #rtn
                        DROP TABLE #indexes
                        ";


            string ddl;
            if (CurrentInformation.ObjectType.Equals("Table"))
            {
                ddl = string.Join(Environment.NewLine,
                    CurrentInformation.ConnectionProperties.Connection.Query<string>(sqlGenTable));
            }
            else if (CurrentInformation.ObjectType.Equals("Constraint"))
            {
                ddl = CurrentInformation.ConnectionProperties.Connection.Query<ConstraintModel>($@"
                    select object_name(tableid) as TableName, 
                    object_name(constrid) as Name,
                    col_name(tableid,sysconstraints.colid) as ColumnName,
                    text as Source
                    from sysconstraints,syscomments
                    where sysconstraints.status=128 and sysconstraints.constrid=syscomments.id and object_name(constrid) = 'SalesOrder_1360004845'
                ").First().Source;
            }
            else
            {
                ddl = CurrentInformation.ConnectionProperties.Connection
                    .Query<string>(CurrentInformation.SqlGenObject()).FirstOrDefault();
            }

            var editForm = new EditForm(string.Join(Environment.NewLine, ddl));
            editForm.Show();
        }

        private void NewConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var connectionForm = new ConnectionForm();
            connectionForm.ShowDialog();

            if (connectionForm.DialogResult != DialogResult.OK)
            {
                return;
            }

            TreeViewConnectionBootstrapper.Init(CurrentInformation.ConnectionProperties, connectionsTreeView);

            connectionsTreeView.Nodes[0].Expand();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "";

            if (CurrentInformation.ObjectType.Equals("Connection"))
            {
                CurrentInformation.Connections.RemoveAll(connection => connection.Name == CurrentInformation.ObjectName);
                return;
            }

            if (CurrentInformation.ObjectType.Equals("Table"))
            {
                sql = $"drop table {CurrentInformation.ObjectName}";

            }
            else if (CurrentInformation.ObjectType.Equals("Trigger"))
            {
                sql = $"drop trigger {CurrentInformation.ObjectName}";
            }
            else if (CurrentInformation.ObjectType.Equals("Function"))
            {
                sql = $"drop function {CurrentInformation.ObjectName}";
            }
            else if (CurrentInformation.ObjectType.Equals("StoredProcedure"))
            {
                sql = $"drop proc {CurrentInformation.ObjectName}";
            }
            else if (CurrentInformation.ObjectType.Equals("View"))
            {
                sql = $"drop view {CurrentInformation.ObjectName}";
            }
           
            var ddlViewer = new DdlViewer(sql);
            ddlViewer.ShowDialog();

            if (ddlViewer.DialogResult == DialogResult.OK)
            {
                CurrentInformation.ConnectionProperties.Connection.Execute(sql);
                connectionsTreeView.Nodes.Remove(connectionsTreeView.SelectedNode);
            }


        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createTableForm = new CreateTableForm(connectionsTreeView);
            createTableForm.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createViewForm = new CreateViewForm(connectionsTreeView);
            createViewForm.Show();

        }

        private void StoredProcedureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var createProcedure = new CreateStoreProcedureForm(connectionsTreeView);
            createProcedure.Show();
        }
    }
}