using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Template
{
    public class Pagination
    {
        [JsonPropertyName("maxCount")]
        public int MaxCount { get; init; }

        [JsonPropertyName("token")]
        public string? Token { get; init; } = null;
    }
}
