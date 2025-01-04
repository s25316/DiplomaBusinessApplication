using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.SpecializedEducations
{
    public class SpecializedEducationDto
    {
        [JsonPropertyName("specializedEducationUuid")]
        public string SpecializedEducationUuid { get; init; }

        [JsonPropertyName("specializedEducationName")]
        public string SpecializedEducationName { get; init; }

        [JsonPropertyName("certificateCode")]
        public int CertificateCode { get; init; }

        [JsonPropertyName("certificateName")]
        public string CertificateName { get; init; }

        [JsonPropertyName("semesterStart")]
        public string SemesterStart { get; init; }

        [JsonPropertyName("institutionUuid")]
        public string InstitutionUuid { get; init; }

        [JsonPropertyName("institutionName")]
        public string InstitutionName { get; init; }

        [JsonPropertyName("dataSource")]
        public string DataSource { get; init; }

        [JsonPropertyName("lastRefresh")]
        public string LastRefresh { get; init; }
    }
}
