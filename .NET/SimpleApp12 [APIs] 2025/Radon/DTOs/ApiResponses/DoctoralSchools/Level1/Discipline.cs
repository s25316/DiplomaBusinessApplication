using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.DoctoralSchools.Level1
{
    public class Discipline
    {
        [JsonPropertyName("disciplineCode")]
        public string DisciplineCode { get; init; }

        [JsonPropertyName("disciplineName")]
        public string DisciplineName { get; init; }
    }
}
