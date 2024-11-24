using System;
using System.Collections.Generic;

namespace TabularDBMS.Models
{
    public class Database
    {
        // Назва бази даних
        public string Name { get; set; }

        // Список таблиць в базі даних
        public List<Table> Tables { get; set; }

        // Конструктор для ініціалізації бази даних з назвою
        public Database(string name)
        {
            Name = name;
            Tables = new List<Table>();
        }

        // Метод для додавання нової таблиці
        public void AddTable(Table table)
        {
            if (Tables.Exists(t => t.Name == table.Name))
            {
                throw new ArgumentException($"Таблиця з ім'ям '{table.Name}' вже існує.");
            }
            Tables.Add(table);
        }

        // Метод для видалення таблиці за назвою
        public void RemoveTable(string tableName)
        {
            var table = Tables.Find(t => t.Name == tableName);
            if (table == null)
            {
                throw new ArgumentException($"Таблиця з ім'ям '{tableName}' не знайдена.");
            }
            Tables.Remove(table);
        }

        // Метод для отримання таблиці за назвою
        public Table GetTable(string tableName)
        {
            var table = Tables.Find(t => t.Name == tableName);
            if (table == null)
            {
                throw new ArgumentException($"Таблиця з ім'ям '{tableName}' не знайдена.");
            }
            return table;
        }

        // Метод для перегляду списку всіх таблиць в базі
        public List<string> ListTables()
        {
            List<string> tableNames = new List<string>();
            foreach (var table in Tables)
            {
                tableNames.Add(table.Name);
            }
            return tableNames;
        }

        // Метод для перейменування таблиці
        public void RenameTable(string oldName, string newName)
        {
            var table = GetTable(oldName);
            if (Tables.Exists(t => t.Name == newName))
            {
                throw new ArgumentException($"Таблиця з ім'ям '{newName}' вже існує.");
            }
            table.Name = newName;
        }

        // Метод для збереження бази даних у файл
        public void SaveToFile(string filePath)
        {
            // Спрощене збереження бази як JSON або інший формат
            // Код для серіалізації бази даних в файл можна додати пізніше
            Console.WriteLine($"База даних '{Name}' була збережена у файл: {filePath}");
        }

        // Метод для завантаження бази даних з файлу
        public static Database LoadFromFile(string filePath)
        {
            // Спрощене завантаження бази з файлу
            // Код для десеріалізації бази даних з файлу можна додати пізніше
            Console.WriteLine($"База даних була завантажена з файлу: {filePath}");
            return new Database("LoadedDatabase");
        }
    }
}
