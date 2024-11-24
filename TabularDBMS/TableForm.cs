using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TabularDBMS.Models;

namespace TabularDBMS
{
    public partial class TableForm : Form
    {
        private Table _table;

        public TableForm(Table table)
        {
            InitializeComponent();
            _table = table;
            Text = $"Table: {_table.Name}";
            InitializeDataGridView();
            LoadData();
        }

        private void InitializeDataGridView()
        {
            // Очищуємо стовпці перед додаванням нових
            dataGridViewRows.Columns.Clear();

            // Додаємо стовпці для DataGridView на основі структури таблиці
            foreach (var column in _table.Columns)
            {
                DataGridViewColumn dataGridViewColumn = new DataGridViewTextBoxColumn
                {
                    HeaderText = column.Name,
                    Name = column.Name
                };

                dataGridViewRows.Columns.Add(dataGridViewColumn);
            }

            // Налаштування DataGridView
            dataGridViewRows.AllowUserToAddRows = false;
            dataGridViewRows.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadData()
        {
            // Очищуємо існуючі рядки перед завантаженням нових даних
            dataGridViewRows.Rows.Clear();

            // Додаємо дані для кожного рядка таблиці
            foreach (var row in _table.Rows)
            {
                var rowData = _table.Columns.Select(c =>
                {
                    var value = row.GetData(c.Name);
                    if (value is Currency currency)
                        return currency.ToString();
                    else if (value is MoneyInterval interval)
                        return interval.ToString();
                    else
                        return value != null ? value.ToString() : string.Empty;
                }).ToArray();

                dataGridViewRows.Rows.Add(rowData);
            }
        }

        private void buttonAddRow_Click(object sender, EventArgs e)
        {
            var addRowForm = new AddEditRowForm(_table.Columns);
            if (addRowForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _table.AddRow(addRowForm.Row);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Adding Row", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            if (dataGridViewRows.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete the selected row(s)?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Сортуємо індекси у зворотному порядку, щоб уникнути зміщення
                var selectedIndices = dataGridViewRows.SelectedRows
                    .OfType<DataGridViewRow>()
                    .Select(r => r.Index)
                    .OrderByDescending(i => i)
                    .ToList();

                foreach (var index in selectedIndices)
                {
                    _table.RemoveRow(index);
                }
                LoadData();
            }
        }

        private void buttonEditRow_Click(object sender, EventArgs e)
        {
            if (dataGridViewRows.SelectedRows.Count != 1)
            {
                MessageBox.Show("Select a single row to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedIndex = dataGridViewRows.SelectedRows[0].Index;
            var row = _table.GetRow(selectedIndex);

            var editRowForm = new AddEditRowForm(_table.Columns, row);
            if (editRowForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _table.Rows[selectedIndex] = editRowForm.Row;
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Editing Row", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRenameColumn_Click(object sender, EventArgs e)
        {
            if (dataGridViewRows.Columns.Count == 0)
                return;

            var selectedColumn = dataGridViewRows.SelectedCells.Count > 0 ? dataGridViewRows.Columns[dataGridViewRows.SelectedCells[0].ColumnIndex] : null;
            if (selectedColumn == null)
            {
                MessageBox.Show("Select a column to rename.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var newName = Prompt.ShowDialog($"Enter new name for column '{selectedColumn.Name}':", "Rename Column");
            if (string.IsNullOrWhiteSpace(newName))
                return;

            try
            {
                _table.RenameColumn(selectedColumn.Name, newName);
                InitializeDataGridView();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Renaming Column", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonReorderColumns_Click(object sender, EventArgs e)
        {
            var reorderForm = new ReorderColumnsForm(_table.Columns.Select(c => c.Name).ToList());
            if (reorderForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _table.ReorderColumns(reorderForm.NewOrder);
                    InitializeDataGridView();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Reordering Columns", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            // Для цієї реалізації зміни вже зберігаються у об'єкті _table
            // Можливо, ви захочете додати додаткові дії, наприклад, автоматичне збереження
            MessageBox.Show("Changes saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
