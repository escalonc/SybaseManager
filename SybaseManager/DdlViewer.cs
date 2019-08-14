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
    public partial class DdlViewer : Form
    {
        public DdlViewer(string ddl)
        {
            InitializeComponent();
            this.Ddl = ddl;
        }

        private string Ddl { get; }

        private void DdlViewer_Load(object sender, EventArgs e)
        {
            ddlTextBox.Text = Ddl;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
