using System;
using System.Collections.Generic;

namespace TabularDBMS.Models
{
    public class Row
    {
        public Dictionary<string, object> Data { get; set; }

        public Row()
        {
            Data = new Dictionary<string, object>();
        }

        public void SetData(string columnName, object value, List<Column> columns)
        {
            var column = columns.Find(c => c.Name == columnName);
            if (column == null)
                throw new ArgumentException($"Column '{columnName}' does not exist.");

            if (!column.Validate(value))
                throw new ArgumentException($"Invalid value type for column '{columnName}'.");

            Data[columnName] = value;
        }

        public object GetData(string columnName)
        {
            return Data.ContainsKey(columnName) ? Data[columnName] : null;
        }
    }
}
