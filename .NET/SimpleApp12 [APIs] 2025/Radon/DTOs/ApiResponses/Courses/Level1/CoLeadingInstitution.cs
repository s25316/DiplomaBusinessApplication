using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Courses.Level1
{
    public class CoLeadingInstitution
    {
        [JsonPropertyName("coLeadingInstitutionUuid")]
        public string CoLeadingInstitutionUuid { get; init; }

        [JsonPropertyName("coLeadingInstitutionName")]
        public string CoLeadingInstitutionName { get; init; }

        [JsonPropertyName("isForeign")]
        public string IsForeign { get; init; }

        [JsonPropertyName("courseUuid")]
        public string CourseUuid { get; init; }

        [JsonPropertyName("courseName")]
        public string CourseName { get; init; }

        [JsonPropertyName("dateFrom")]
        public string DateFrom { get; init; }

        [JsonPropertyName("dateTo")]
        public string DateTo { get; init; }

        [JsonPropertyName("coLedFosConfirmationStatus")]
        public string CoLedFosConfirmationStatus { get; init; }
    }
}
