using System;
using System.Text.Json.Serialization;

namespace TabularDBMS.Models
{
    public class MoneyInterval
    {
        [JsonPropertyName("Start")]
        public Currency Start { get; set; }

        [JsonPropertyName("End")]
        public Currency End { get; set; }

        public MoneyInterval(decimal start, decimal end)
        {
            if (start > end)
                throw new ArgumentException("Start of interval cannot be greater than end.");
            Start = new Currency(start);
            End = new Currency(end);
        }

        // Пустий конструктор для десеріалізації
        public MoneyInterval() { }

        public override string ToString()
        {
            return $"[{Start.Value}, {End.Value}]";
        }
    }
}
