using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Institutions.Level1
{
    public class SupervisingInstitution
    {
        [JsonPropertyName("supervisingInstitutionID")]
        public Guid SupervisingInstitutionID { get; init; }

        [JsonPropertyName("supervisingInstitutionName")]
        public string SupervisingInstitutionName { get; init; } = null!;

        [JsonPropertyName("dateFrom")]
        public string DateFrom { get; init; } = null!;

    }
}
