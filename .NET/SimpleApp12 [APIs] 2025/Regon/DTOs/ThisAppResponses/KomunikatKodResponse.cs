using Regon.Enums;
using System.Text.Json.Serialization;

namespace Regon.DTOs.ThisAppResponses
{
    public class KomunikatKodResponse
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public KomunikatKodEnum KomunikatKod { get; init; }
        public string Message { get; init; } = null!;

    }
}
