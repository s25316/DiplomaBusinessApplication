using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Institutions.Level1
{
    public class TargetInstitutionDto
    {
        [JsonPropertyName("targetInstitutionUuid")]
        public Guid TargetInstitutionUuid { get; init; }

        [JsonPropertyName("targetInstitutionName")]
        public string TargetInstitutionName { get; init; } = null!;

        [JsonPropertyName("regon")]
        public string Regon { get; init; } = null!;

        [JsonPropertyName("nip")]
        public string Nip { get; init; } = null!;

        [JsonPropertyName("krs")]
        public string? Krs { get; init; } = null;

        [JsonPropertyName("eunNumber")]
        public string EunNumber { get; init; } = null!;

        [JsonPropertyName("panNumber")]
        public string PanNumber { get; init; } = null!;

        [JsonPropertyName("supervisingInstitutionID")]
        public string SupervisingInstitutionID { get; init; } = null!;

        [JsonPropertyName("supervisingInstitutionName")]
        public string SupervisingInstitutionName { get; init; } = null!;

        [JsonPropertyName("transformationKind")]
        public string TransformationKind { get; init; } = null!;

        [JsonPropertyName("transformationDate")]
        public string TransformationDate { get; init; } = null!;
    }
}
