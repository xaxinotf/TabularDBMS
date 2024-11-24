using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TabularDBMS.Models
{
    public class DataTypeConverter : JsonConverter<object>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(object).IsAssignableFrom(typeToConvert);
        }

        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<object>(ref reader, options);
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case Currency currency:
                    JsonSerializer.Serialize(writer, currency, options);
                    break;
                case MoneyInterval interval:
                    JsonSerializer.Serialize(writer, interval, options);
                    break;
                default:
                    JsonSerializer.Serialize(writer, value, options);
                    break;
            }
        }
    }
}
