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
    public partial class EditForm : Form
    {
        public EditForm(string ddl)
        {
            InitializeComponent();
            Ddl = ddl;
        }

        private string Ddl { get; }

        private void EditForm_Load(object sender, EventArgs e)
        {
            ddlTextBox.Text = Ddl;
        }
    }
}
