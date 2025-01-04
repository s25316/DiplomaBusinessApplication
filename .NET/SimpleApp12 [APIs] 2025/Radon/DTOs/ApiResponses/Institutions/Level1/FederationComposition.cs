using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Institutions.Level1
{
    public class FederationComposition
    {
        [JsonPropertyName("institutionUuid")]
        public Guid InstitutionUuid { get; init; }

        [JsonPropertyName("institutionName")]
        public string InstitutionName { get; init; } = null!;

        [JsonPropertyName("dateFrom")]
        public string DateFrom { get; init; } = null!;

        [JsonPropertyName("dateTo")]
        public string? DateTo { get; init; } = null;
    }
}
