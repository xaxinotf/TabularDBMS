using System;
using System.Text.Json.Serialization;

namespace TabularDBMS.Models
{
    public class Currency
    {
        [JsonPropertyName("Value")]
        public decimal Value { get; set; }

        public const decimal MaxValue = 10000000000000.00m; // 10 трильйонів

        public Currency(decimal value)
        {
            if (value < 0 || value > MaxValue)
                throw new ArgumentOutOfRangeException($"Currency value must be between 0 and {MaxValue}");
            Value = value;
        }

        // Пустий конструктор для десеріалізації
        public Currency() { }

        public override string ToString()
        {
            return Value.ToString("C2");
        }
    }
}
