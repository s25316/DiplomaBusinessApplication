using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.DoctoralSchools.Level1
{
    public class CoLeadingInstitution
    {
        [JsonPropertyName("coLeadingInstitutionUuid")]
        public string CoLeadingInstitutionUuid { get; init; }

        [JsonPropertyName("coLeadingInstitutionName")]
        public string CoLeadingInstitutionName { get; init; }
    }
}
