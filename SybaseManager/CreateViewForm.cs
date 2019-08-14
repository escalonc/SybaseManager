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
    public partial class CreateViewForm : Form
    {
        public CreateViewForm(TreeView treeView)
        {
            TreeView = treeView;
            InitializeComponent();
        }

        public TreeView TreeView { get; }

        private void Button1_Click(object sender, EventArgs e)
        {
            string baseSql = $"create view {nameTextBox.Text} as {sqlTextBox.Text}";


            var ddlViewer = new DdlViewer(baseSql);
            ddlViewer.ShowDialog();

            if (ddlViewer.DialogResult != DialogResult.OK) return;
            CurrentInformation.ConnectionProperties.Connection.Execute(baseSql);
            TreeViewConnectionBootstrapper.Init(CurrentInformation.ConnectionProperties, TreeView);
        }
    }
}
