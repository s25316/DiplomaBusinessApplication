using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Courses.Level1
{
    public class Discipline
    {
        [JsonPropertyName("disciplineCode")]
        public string DisciplineCode { get; init; } = null!;

        [JsonPropertyName("disciplineName")]
        public string DisciplineName { get; init; } = null!;

        [JsonPropertyName("disciplinePercentageShare")]
        public string DisciplinePercentageShare { get; init; } = null!;

        [JsonPropertyName("disciplineLeading")]
        public string DisciplineLeading { get; init; } = null!;
    }
}
