using System;
using System.Collections.Generic;

namespace TabularDBMS.Models
{
    public class Table
    {
        public string Name { get; set; }
        public List<Column> Columns { get; set; }
        public List<Row> Rows { get; set; }

        public Table(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Table name cannot be empty.");
            Name = name;
            Columns = new List<Column>();
            Rows = new List<Row>();
        }

        public void AddColumn(Column column)
        {
            if (Columns.Exists(c => c.Name.Equals(column.Name, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException($"Column '{column.Name}' already exists.");
            Columns.Add(column);
        }

        public void RemoveColumn(string columnName)
        {
            var column = Columns.Find(c => c.Name == columnName);
            if (column == null)
                throw new ArgumentException($"Column '{columnName}' does not exist.");
            Columns.Remove(column);

            // Видалення даних з рядків
            foreach (var row in Rows)
            {
                if (row.Data.ContainsKey(columnName))
                    row.Data.Remove(columnName);
            }
        }

        public void RenameColumn(string oldName, string newName)
        {
            var column = Columns.Find(c => c.Name == oldName);
            if (column == null)
                throw new ArgumentException($"Column '{oldName}' does not exist.");
            if (Columns.Exists(c => c.Name.Equals(newName, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException($"Column '{newName}' already exists.");
            column.Name = newName;

            // Оновлення ключів у рядках
            foreach (var row in Rows)
            {
                if (row.Data.ContainsKey(oldName))
                {
                    row.Data[newName] = row.Data[oldName];
                    row.Data.Remove(oldName);
                }
            }
        }

        public void ReorderColumns(List<string> newOrder)
        {
            if (newOrder.Count != Columns.Count)
                throw new ArgumentException("New order must include all existing columns.");

            var reorderedColumns = new List<Column>();
            foreach (var name in newOrder)
            {
                var column = Columns.Find(c => c.Name == name);
                if (column == null)
                    throw new ArgumentException($"Column '{name}' does not exist.");
                reorderedColumns.Add(column);
            }

            Columns = reorderedColumns;
        }

        public void AddRow(Row row)
        {
            // Валідація рядка згідно схеми таблиці
            foreach (var column in Columns)
            {
                if (!row.Data.ContainsKey(column.Name))
                    throw new ArgumentException($"Row is missing data for column '{column.Name}'.");
                if (!column.Validate(row.Data[column.Name]))
                    throw new ArgumentException($"Invalid data type for column '{column.Name}'.");
            }
            Rows.Add(row);
        }

        public void RemoveRow(int index)
        {
            if (index < 0 || index >= Rows.Count)
                throw new IndexOutOfRangeException("Row index is out of range.");
            Rows.RemoveAt(index);
        }

        public Row GetRow(int index)
        {
            if (index < 0 || index >= Rows.Count)
                throw new IndexOutOfRangeException("Row index is out of range.");
            return Rows[index];
        }
    }
}
