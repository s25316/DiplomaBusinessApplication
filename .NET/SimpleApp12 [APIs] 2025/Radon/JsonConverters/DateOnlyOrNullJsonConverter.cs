using System.Text.Json;
using System.Text.Json.Serialization;

namespace Radon.JsonConverters
{
    public class DateOnlyOrNullJsonConverter : JsonConverter<DateOnly?>
    {
        public override DateOnly? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var dateString = reader.GetString();
            if (string.IsNullOrWhiteSpace(dateString))
            {
                return null;
            }
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
            DateOnly? value,
            JsonSerializerOptions options)
        {
            if (value != null)
            {
                writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd"));
            }
        }
    }
}
