using System;
using System.Drawing;
using SybaseManager.Core.Factories;
using SybaseManager.Core.Models;
using System.Windows.Forms;

namespace SybaseManager
{
    public partial class ConnectionForm : Form
    {
        public ConnectionForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeConnection();
                CurrentInformation.AddConnection(CurrentInformation.ConnectionProperties);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (SybaseManagerException ex)
            {
                SetStatusError(ex.Message);
            }
            catch (Exception)
            {
                SetStatusError();
            }
        }

        private void ConnectionForm_Load(object sender, EventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeConnection()
        {
            var connection = new SybaseConnectionFactory().Create(new ConnectionConfiguration
            {
                DatabaseName = databaseTextBox.Text,
                HostName = hostTextBox.Text,
                Password = passwordTextBox.Text,
                UserName = usernameTextBox.Text
            });

            connection.Open();

            CurrentInformation.ConnectionProperties = new ConnectionInformation
            {
                Connection = connection,
                Name = connectionNameTextBox.Text
            };

            statusLabel.Text = "Connection created successfully";
            statusLabel.ForeColor = Color.Green;
        }

        private void SetStatusError(string message = "Error when trying to establish the connection")
        {
            
            statusLabel.Text = message;
            statusLabel.ForeColor = Color.Red;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeConnection();
                
            }
            catch (SybaseManagerException ex)
            {
                SetStatusError(ex.Message);
            }
            catch (Exception)
            {
                SetStatusError();
            }
        }
    }
}