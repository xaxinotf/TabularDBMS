namespace TabularDBMS
{
    partial class TableForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewRows;
        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Button buttonDeleteRow;
        private System.Windows.Forms.Button buttonEditRow;
        private System.Windows.Forms.Button buttonRenameColumn;
        private System.Windows.Forms.Button buttonReorderColumns;
        private System.Windows.Forms.Button buttonSaveChanges;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dataGridViewRows = new System.Windows.Forms.DataGridView();
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            this.buttonEditRow = new System.Windows.Forms.Button();
            this.buttonRenameColumn = new System.Windows.Forms.Button();
            this.buttonReorderColumns = new System.Windows.Forms.Button();
            this.buttonSaveChanges = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRows)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRows
            // 
            this.dataGridViewRows.AllowUserToAddRows = false;
            this.dataGridViewRows.AllowUserToDeleteRows = false;
            this.dataGridViewRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRows.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewRows.Name = "dataGridViewRows";
            this.dataGridViewRows.ReadOnly = true;
            this.dataGridViewRows.RowTemplate.Height = 25;
            this.dataGridViewRows.Size = new System.Drawing.Size(760, 400);
            this.dataGridViewRows.TabIndex = 0;
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Location = new System.Drawing.Point(12, 430);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(100, 30);
            this.buttonAddRow.TabIndex = 1;
            this.buttonAddRow.Text = "Add Row";
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddRow_Click);
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.Location = new System.Drawing.Point(130, 430);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(100, 30);
            this.buttonDeleteRow.TabIndex = 2;
            this.buttonDeleteRow.Text = "Delete Row";
            this.buttonDeleteRow.UseVisualStyleBackColor = true;
            this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
            // 
            // buttonEditRow
            // 
            this.buttonEditRow.Location = new System.Drawing.Point(250, 430);
            this.buttonEditRow.Name = "buttonEditRow";
            this.buttonEditRow.Size = new System.Drawing.Size(100, 30);
            this.buttonEditRow.TabIndex = 3;
            this.buttonEditRow.Text = "Edit Row";
            this.buttonEditRow.UseVisualStyleBackColor = true;
            this.buttonEditRow.Click += new System.EventHandler(this.buttonEditRow_Click);
            // 
            // buttonRenameColumn
            // 
            this.buttonRenameColumn.Location = new System.Drawing.Point(370, 430);
            this.buttonRenameColumn.Name = "buttonRenameColumn";
            this.buttonRenameColumn.Size = new System.Drawing.Size(130, 30);
            this.buttonRenameColumn.TabIndex = 4;
            this.buttonRenameColumn.Text = "Rename Column";
            this.buttonRenameColumn.UseVisualStyleBackColor = true;
            this.buttonRenameColumn.Click += new System.EventHandler(this.buttonRenameColumn_Click);
            // 
            // buttonReorderColumns
            // 
            this.buttonReorderColumns.Location = new System.Drawing.Point(520, 430);
            this.buttonReorderColumns.Name = "buttonReorderColumns";
            this.buttonReorderColumns.Size = new System.Drawing.Size(130, 30);
            this.buttonReorderColumns.TabIndex = 5;
            this.buttonReorderColumns.Text = "Reorder Columns";
            this.buttonReorderColumns.UseVisualStyleBackColor = true;
            this.buttonReorderColumns.Click += new System.EventHandler(this.buttonReorderColumns_Click);
            // 
            // buttonSaveChanges
            // 
            this.buttonSaveChanges.Location = new System.Drawing.Point(670, 430);
            this.buttonSaveChanges.Name = "buttonSaveChanges";
            this.buttonSaveChanges.Size = new System.Drawing.Size(100, 30);
            this.buttonSaveChanges.TabIndex = 6;
            this.buttonSaveChanges.Text = "Save Changes";
            this.buttonSaveChanges.UseVisualStyleBackColor = true;
            this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click);
            // 
            // TableForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 481);
            this.Controls.Add(this.buttonSaveChanges);
            this.Controls.Add(this.buttonReorderColumns);
            this.Controls.Add(this.buttonRenameColumn);
            this.Controls.Add(this.buttonEditRow);
            this.Controls.Add(this.buttonDeleteRow);
            this.Controls.Add(this.buttonAddRow);
            this.Controls.Add(this.dataGridViewRows);
            this.Name = "TableForm";
            this.Text = "Table";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRows)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
