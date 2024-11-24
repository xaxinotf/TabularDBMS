using System;

namespace TabularDBMS.Models
{
    public class Column
    {
        public string Name { get; set; }
        public DataType Type { get; set; }

        public Column(string name, DataType type)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Column name cannot be empty.");
            Name = name;
            Type = type;
        }

        // Метод для валідації значення згідно типу
        public bool Validate(object value)
        {
            try
            {
                switch (Type)
                {
                    case DataType.Integer:
                        if (!(value is int))
                            return false;
                        break;
                    case DataType.Real:
                        if (!(value is double))
                            return false;
                        break;
                    case DataType.Char:
                        if (!(value is char))
                            return false;
                        break;
                    case DataType.String:
                        if (!(value is string))
                            return false;
                        break;
                    case DataType.Currency:
                        if (!(value is Currency))
                            return false;
                        break;
                    case DataType.MoneyInterval:
                        if (!(value is MoneyInterval))
                            return false;
                        break;
                    default:
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
