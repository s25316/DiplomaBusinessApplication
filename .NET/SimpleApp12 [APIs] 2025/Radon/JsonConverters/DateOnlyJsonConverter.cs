using System.Text.Json;
using System.Text.Json.Serialization;

namespace Radon.JsonConverters
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var dateString = reader.GetString();
            if (DateTime.TryParse(dateString, out var dateTime))
            {
                return DateOnly.FromDateTime(dateTime);
            }
            else
            {
                throw new Exception($"Invalid input data: {dateString}");
            }
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateOnly value,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
        }
    }
}
