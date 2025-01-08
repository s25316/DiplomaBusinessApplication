using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Disciplines
{
    public class Discipline
    {
        [JsonPropertyName("namePl")]
        public string NamePl { get; init; } = null!;
        [JsonPropertyName("nameEn")]
        public string NameEng { get; init; } = null!;
        [JsonPropertyName("code")]
        public string Code { get; init; } = null!;
    }
}
