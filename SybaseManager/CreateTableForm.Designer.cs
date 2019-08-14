namespace SybaseManager
{
    partial class CreateTableForm
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableDefinitionDataGrid = new System.Windows.Forms.DataGridView();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PrimaryKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NotNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableDefinitionDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(67, 29);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(183, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // tableDefinitionDataGrid
            // 
            this.tableDefinitionDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableDefinitionDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FieldName,
            this.DataType,
            this.PrimaryKey,
            this.NotNull});
            this.tableDefinitionDataGrid.Location = new System.Drawing.Point(12, 71);
            this.tableDefinitionDataGrid.Name = "tableDefinitionDataGrid";
            this.tableDefinitionDataGrid.Size = new System.Drawing.Size(776, 297);
            this.tableDefinitionDataGrid.TabIndex = 2;
            // 
            // FieldName
            // 
            this.FieldName.HeaderText = "Name";
            this.FieldName.Name = "FieldName";
            // 
            // DataType
            // 
            this.DataType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.DataType.HeaderText = "Data Type";
            this.DataType.Items.AddRange(new object[] {
            "varchar",
            "int",
            "decimal"});
            this.DataType.Name = "DataType";
            // 
            // PrimaryKey
            // 
            this.PrimaryKey.HeaderText = "Primary key";
            this.PrimaryKey.Name = "PrimaryKey";
            // 
            // NotNull
            // 
            this.NotNull.HeaderText = "Not null";
            this.NotNull.Name = "NotNull";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 390);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 47);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // CreateTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 455);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableDefinitionDataGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTextBox);
            this.Name = "CreateTableForm";
            this.Text = "Create table";
            this.Load += new System.EventHandler(this.CreateTableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableDefinitionDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tableDefinitionDataGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewComboBoxColumn DataType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PrimaryKey;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NotNull;
    }
}