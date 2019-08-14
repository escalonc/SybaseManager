namespace SybaseManager
{
    partial class CreateStoreProcedureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.procedureParametersDataGrid = new System.Windows.Forms.DataGridView();
            this.ParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.procedureDefinitionTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.procedureParametersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(67, 23);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(198, 20);
            this.nameTextBox.TabIndex = 7;
            // 
            // procedureParametersDataGrid
            // 
            this.procedureParametersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.procedureParametersDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParameterName,
            this.DataType});
            this.procedureParametersDataGrid.Location = new System.Drawing.Point(12, 77);
            this.procedureParametersDataGrid.Name = "procedureParametersDataGrid";
            this.procedureParametersDataGrid.Size = new System.Drawing.Size(436, 179);
            this.procedureParametersDataGrid.TabIndex = 9;
            // 
            // ParameterName
            // 
            this.ParameterName.HeaderText = "Name";
            this.ParameterName.Name = "ParameterName";
            // 
            // DataType
            // 
            this.DataType.HeaderText = "Mode";
            this.DataType.Items.AddRange(new object[] {
            "IN",
            "OUT"});
            this.DataType.Name = "DataType";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 413);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 47);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // procedureDefinitionTextBox
            // 
            this.procedureDefinitionTextBox.Location = new System.Drawing.Point(15, 275);
            this.procedureDefinitionTextBox.Multiline = true;
            this.procedureDefinitionTextBox.Name = "procedureDefinitionTextBox";
            this.procedureDefinitionTextBox.Size = new System.Drawing.Size(433, 132);
            this.procedureDefinitionTextBox.TabIndex = 11;
            // 
            // CreateStoreProcedureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 472);
            this.Controls.Add(this.procedureDefinitionTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.procedureParametersDataGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTextBox);
            this.Name = "CreateStoreProcedureForm";
            this.Text = "Create procedure";
            ((System.ComponentModel.ISupportInitialize)(this.procedureParametersDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.DataGridView procedureParametersDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParameterName;
        private System.Windows.Forms.DataGridViewComboBoxColumn DataType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox procedureDefinitionTextBox;
    }
}