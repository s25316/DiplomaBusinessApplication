using Radon.DTOs.ApiResponses.DoctoralSchools.Level2;
using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.DoctoralSchools.Level1
{
    public class Program
    {
        [JsonPropertyName("programUuid")]
        public string ProgramUuid { get; init; }

        [JsonPropertyName("programName")]
        public string ProgramName { get; init; }

        [JsonPropertyName("programScope")]
        public string ProgramScope { get; init; }

        [JsonPropertyName("educationStartDate")]
        public string EducationStartDate { get; init; }

        [JsonPropertyName("numberOfSemesters")]
        public int NumberOfSemesters { get; init; }

        [JsonPropertyName("iscedCode")]
        public string IscedCode { get; init; }

        [JsonPropertyName("disciplines")]
        public List<Discipline> Disciplines { get; init; }

        [JsonPropertyName("educationEndDate")]
        public string EducationEndDate { get; init; }

        [JsonPropertyName("cooperatingInstitutions")]
        public List<CooperatingInstitution> CooperatingInstitutions { get; init; } = new();
    }
}
