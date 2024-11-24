using System;
using System.Windows.Forms;
using TabularDBMS.Models;

namespace TabularDBMS
{
    public partial class MainForm : Form
    {
        private Database _database;

        public MainForm()
        {
            InitializeComponent();
            _database = new Database("MyDatabase");
            UpdateTablesList();
        }

        private void UpdateTablesList()
        {
            listBoxTables.Items.Clear();
            foreach (var tableName in _database.ListTables())
            {
                listBoxTables.Items.Add(tableName);
            }
        }

        private void buttonCreateTable_Click(object sender, EventArgs e)
        {
            var input = Prompt.ShowDialog("Enter table name:", "Create Table");
            if (string.IsNullOrWhiteSpace(input))
                return;

            try
            {
                var table = new Table(input);
                _database.AddTable(table);
                UpdateTablesList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Creating Table", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeleteTable_Click(object sender, EventArgs e)
        {
            if (listBoxTables.SelectedItem == null)
            {
                MessageBox.Show("Select a table to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tableName = listBoxTables.SelectedItem.ToString();
            var confirm = MessageBox.Show($"Are you sure you want to delete table '{tableName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _database.RemoveTable(tableName);
                    UpdateTablesList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Deleting Table", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonOpenTable_Click(object sender, EventArgs e)
        {
            if (listBoxTables.SelectedItem == null)
            {
                MessageBox.Show("Select a table to open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var tableName = listBoxTables.SelectedItem.ToString();
            var table = _database.GetTable(tableName);
            var tableForm = new TableForm(table);
            tableForm.ShowDialog();
            // Після закриття TableForm можливо оновити дані
        }

        private void buttonSaveDatabase_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON Files (*.json)|*.json";
                saveFileDialog.Title = "Save Database";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _database.SaveToFile(saveFileDialog.FileName);
                        MessageBox.Show("Database saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Saving Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonLoadDatabase_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files (*.json)|*.json";
                openFileDialog.Title = "Load Database";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _database = Database.LoadFromFile(openFileDialog.FileName);
                        UpdateTablesList();
                        MessageBox.Show("Database loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Loading Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
