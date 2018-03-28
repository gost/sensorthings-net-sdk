using System;
using Newtonsoft.Json;
using sensorthings.Core;

namespace sensorthings.Converters
{
    public class DateTimeRangeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;            
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.Date && reader.TokenType != JsonToken.String)
            {
                throw new Exception($"Unexpected token parsing date. Expected String or Date, got {reader.TokenType}.");
            }

            var stringRepresentation = reader.Value as string;
            if (reader.TokenType == JsonToken.Date)
            {
                stringRepresentation = ((DateTime)reader.Value).ToUniversalTime().ToString(DateTimeRange.TimeFormat);
            }

            return new DateTimeRange(stringRepresentation);            
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string dateTimeRange;
            if (value is DateTimeRange range)
            {
                dateTimeRange = range.ToString();
            }
            else
            {
                throw new Exception("Expected DateTimeRange object value.");
            }

            writer.WriteValue(dateTimeRange);
        }
    }
}
