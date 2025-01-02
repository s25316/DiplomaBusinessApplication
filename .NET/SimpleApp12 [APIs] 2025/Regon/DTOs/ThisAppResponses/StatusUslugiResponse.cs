using Regon.Enums;
using System.Text.Json.Serialization;

namespace Regon.DTOs.ThisAppResponses
{
    public class StatusUslugiResponse
    {
        public bool IsActive { get; init; } = false;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusUslugiEnum Status { get; init; }
        public string? Message { get; init; }
    }
}
