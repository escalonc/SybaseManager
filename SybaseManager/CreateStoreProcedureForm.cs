using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Windows.Forms;

namespace SybaseManager
{
    public partial class CreateStoreProcedureForm : Form
    {
        public CreateStoreProcedureForm(TreeView treeView)
        {
            TreeView = treeView;
            InitializeComponent();
        }

        public TreeView TreeView { get; set; }

        private void Button1_Click(object sender, EventArgs e)
        {
            var baseSql = $"create proc {nameTextBox.Text} (";

            foreach (DataGridViewRow row in procedureParametersDataGrid.Rows)
            {
                if (!row.IsNewRow)
                {
                    baseSql += $"@{row.Cells["ParameterName"].Value} {row.Cells["DataType"].Value},";
                }
            }

            var newSql = baseSql.Remove(baseSql.Length - 1);

            newSql += $") as {procedureDefinitionTextBox.Text}";

            var ddlViewer = new DdlViewer(baseSql);
            ddlViewer.ShowDialog();

            if (ddlViewer.DialogResult != DialogResult.OK) return;
            CurrentInformation.ConnectionProperties.Connection.Execute(baseSql);
            TreeViewConnectionBootstrapper.Init(CurrentInformation.ConnectionProperties, TreeView);
        }
    }
}
