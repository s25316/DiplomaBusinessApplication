using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Shared
{
    public class StatusDto
    {
        [JsonPropertyName("statusName")]
        public string StatusName { get; init; } = null!;

        [JsonPropertyName("dateFrom")]
        public string DateFrom { get; init; } = null!;
    }
}
