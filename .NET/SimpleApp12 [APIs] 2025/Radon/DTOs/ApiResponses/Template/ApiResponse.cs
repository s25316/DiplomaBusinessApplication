using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Template
{
    public class ApiResponse<T>
    {
        [JsonPropertyName("results")]
        public List<T> Results { get; init; } = new List<T>();

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; init; } = null!;

        [JsonPropertyName("version")]
        public string Version { get; init; } = null!;
    }
}
