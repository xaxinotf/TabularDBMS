namespace TabularDBMS
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxTables;
        private System.Windows.Forms.Button buttonCreateTable;
        private System.Windows.Forms.Button buttonDeleteTable;
        private System.Windows.Forms.Button buttonOpenTable;
        private System.Windows.Forms.Button buttonSaveDatabase;
        private System.Windows.Forms.Button buttonLoadDatabase;

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
            this.listBoxTables = new System.Windows.Forms.ListBox();
            this.buttonCreateTable = new System.Windows.Forms.Button();
            this.buttonDeleteTable = new System.Windows.Forms.Button();
            this.buttonOpenTable = new System.Windows.Forms.Button();
            this.buttonSaveDatabase = new System.Windows.Forms.Button();
            this.buttonLoadDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxTables
            // 
            this.listBoxTables.FormattingEnabled = true;
            this.listBoxTables.ItemHeight = 15;
            this.listBoxTables.Location = new System.Drawing.Point(12, 12);
            this.listBoxTables.Name = "listBoxTables";
            this.listBoxTables.Size = new System.Drawing.Size(200, 379);
            this.listBoxTables.TabIndex = 0;
            // 
            // buttonCreateTable
            // 
            this.buttonCreateTable.Location = new System.Drawing.Point(230, 12);
            this.buttonCreateTable.Name = "buttonCreateTable";
            this.buttonCreateTable.Size = new System.Drawing.Size(150, 30);
            this.buttonCreateTable.TabIndex = 1;
            this.buttonCreateTable.Text = "Create Table";
            this.buttonCreateTable.UseVisualStyleBackColor = true;
            this.buttonCreateTable.Click += new System.EventHandler(this.buttonCreateTable_Click);
            // 
            // buttonDeleteTable
            // 
            this.buttonDeleteTable.Location = new System.Drawing.Point(230, 60);
            this.buttonDeleteTable.Name = "buttonDeleteTable";
            this.buttonDeleteTable.Size = new System.Drawing.Size(150, 30);
            this.buttonDeleteTable.TabIndex = 2;
            this.buttonDeleteTable.Text = "Delete Table";
            this.buttonDeleteTable.UseVisualStyleBackColor = true;
            this.buttonDeleteTable.Click += new System.EventHandler(this.buttonDeleteTable_Click);
            // 
            // buttonOpenTable
            // 
            this.buttonOpenTable.Location = new System.Drawing.Point(230, 108);
            this.buttonOpenTable.Name = "buttonOpenTable";
            this.buttonOpenTable.Size = new System.Drawing.Size(150, 30);
            this.buttonOpenTable.TabIndex = 3;
            this.buttonOpenTable.Text = "Open Table";
            this.buttonOpenTable.UseVisualStyleBackColor = true;
            this.buttonOpenTable.Click += new System.EventHandler(this.buttonOpenTable_Click);
            // 
            // buttonSaveDatabase
            // 
            this.buttonSaveDatabase.Location = new System.Drawing.Point(230, 156);
            this.buttonSaveDatabase.Name = "buttonSaveDatabase";
            this.buttonSaveDatabase.Size = new System.Drawing.Size(150, 30);
            this.buttonSaveDatabase.TabIndex = 4;
            this.buttonSaveDatabase.Text = "Save Database";
            this.buttonSaveDatabase.UseVisualStyleBackColor = true;
            this.buttonSaveDatabase.Click += new System.EventHandler(this.buttonSaveDatabase_Click);
            // 
            // buttonLoadDatabase
            // 
            this.buttonLoadDatabase.Location = new System.Drawing.Point(230, 204);
            this.buttonLoadDatabase.Name = "buttonLoadDatabase";
            this.buttonLoadDatabase.Size = new System.Drawing.Size(150, 30);
            this.buttonLoadDatabase.TabIndex = 5;
            this.buttonLoadDatabase.Text = "Load Database";
            this.buttonLoadDatabase.UseVisualStyleBackColor = true;
            this.buttonLoadDatabase.Click += new System.EventHandler(this.buttonLoadDatabase_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.buttonLoadDatabase);
            this.Controls.Add(this.buttonSaveDatabase);
            this.Controls.Add(this.buttonOpenTable);
            this.Controls.Add(this.buttonDeleteTable);
            this.Controls.Add(this.buttonCreateTable);
            this.Controls.Add(this.listBoxTables);
            this.Name = "MainForm";
            this.Text = "TabularDBMS - Main";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
