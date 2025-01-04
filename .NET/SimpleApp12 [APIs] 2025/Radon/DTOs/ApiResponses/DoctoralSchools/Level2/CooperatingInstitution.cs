using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.DoctoralSchools.Level2
{
    public class CooperatingInstitution
    {
        [JsonPropertyName("cooperatingInstitutionUuid")]
        public string CooperatingInstitutionUuid { get; init; }

        [JsonPropertyName("cooperatingInstitutionName")]
        public string CooperatingInstitutionName { get; init; }
    }
}
