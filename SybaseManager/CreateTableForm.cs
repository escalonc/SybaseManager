using System;
using Dapper;
using System.Windows.Forms;

namespace SybaseManager
{
    public partial class CreateTableForm : Form
    {
        public CreateTableForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string baseSql = $"create table {nameTextBox.Text} (";

            foreach (DataGridViewRow row in tableDefinitionDataGrid.Rows)
            {
                if (!row.IsNewRow)
                {
                    baseSql += $"{row.Cells["FieldName"].Value} {row.Cells["DataType"].Value}";
                    if (row.Cells["NotNull"].Value != null && (bool) row.Cells["NotNull"].Value)
                    {
                        baseSql += " NOT NULL";
                    }

                    if (row.Cells["PrimaryKey"].Value != null && (bool) row.Cells["PrimaryKey"].Value)
                    {
                        baseSql += " PRIMARY KEY";
                    }

                    baseSql += ",";
                }
            }

            baseSql += ");";

            var ddlViewer = new DdlViewer(baseSql);
            ddlViewer.ShowDialog();

            if (ddlViewer.DialogResult != DialogResult.OK) return;
            CurrentInformation.ConnectionProperties.Connection.Execute(baseSql);
            tableDefinitionDataGrid.DataSource = null;
        }

        private void CreateTableForm_Load(object sender, EventArgs e)
        {
        }
    }
}