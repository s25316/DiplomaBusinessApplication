using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Courses.Level1
{
    public class PhilologicalLanguage
    {
        [JsonPropertyName("languageCode")]
        public string LanguageCode { get; init; } = null!;

        [JsonPropertyName("languageName")]
        public string LanguageName { get; init; } = null!;
    }
}
