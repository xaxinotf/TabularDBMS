//using System;
//using Xunit;
//using TabularDBMS.Models; // Переконайтесь, що простір імен правильний
//using System.Collections.Generic;

//namespace TabularDBMSTests
//{
//    public class DatabaseTests
//    {
//        [Fact]
//        public void AddTable_ShouldAddTableToDatabase()
//        {
//            var db = new Database("TestDB");
//            var table = new Table("Employees");
//            db.AddTable(table);
//            Assert.Contains("Employees", db.ListTables());
//        }

//        [Fact]
//        public void RemoveTable_ShouldRemoveTableFromDatabase()
//        {
//            var db = new Database("TestDB");
//            var table = new Table("Employees");
//            db.AddTable(table);
//            db.RemoveTable("Employees");
//            Assert.DoesNotContain("Employees", db.ListTables());
//        }

//        [Fact]
//        public void AddRow_ShouldIncreaseRowCount()
//        {
//            var table = new Table("Employees");
//            table.AddColumn(new Column("ID", DataType.Integer));
//            table.AddColumn(new Column("Name", DataType.String));

//            var row = new Row();
//            row.SetData("ID", 1, table.Columns);
//            row.SetData("Name", "John Doe", table.Columns);
//            table.AddRow(row);

//            Assert.Equal(1, table.Rows.Count);
//        }

//        [Fact]
//        public void AddRow_InvalidData_ShouldThrowException()
//        {
//            var table = new Table("Employees");
//            table.AddColumn(new Column("ID", DataType.Integer));
//            table.AddColumn(new Column("Name", DataType.String));

//            var row = new Row();
//            row.SetData("ID", "NotAnInteger", table.Columns); // Некоректний тип

//            Assert.Throws<ArgumentException>(() => table.AddRow(row));
//        }

//        [Fact]
//        public void Currency_ExceedsMaxValue_ShouldThrowException()
//        {
//            Assert.Throws<ArgumentOutOfRangeException>(() => new Currency(10000000000000.01m));
//        }

//        // Тест для індивідуальної операції: Перестановка колонок
//        [Fact]
//        public void ReorderColumns_ShouldChangeColumnOrder()
//        {
//            var table = new Table("Employees");
//            table.AddColumn(new Column("ID", DataType.Integer));
//            table.AddColumn(new Column("Name", DataType.String));
//            table.AddColumn(new Column("Salary", DataType.Currency));

//            var newOrder = new List<string> { "Salary", "Name", "ID" };
//            table.ReorderColumns(newOrder);

//            Assert.Equal("Salary", table.Columns[0].Name);
//            Assert.Equal("Name", table.Columns[1].Name);
//            Assert.Equal("ID", table.Columns[2].Name);
//        }
//    }
//}
