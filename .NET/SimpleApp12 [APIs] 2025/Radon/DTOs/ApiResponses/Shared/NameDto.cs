using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Shared
{
    public class NameDto
    {
        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("dateFrom")]
        public string DateFrom { get; init; } = null!;
    }
}
