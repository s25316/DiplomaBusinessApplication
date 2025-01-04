using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Courses.Level1
{
    public class CourseInstance
    {
        [JsonPropertyName("courseInstanceUuid")]
        public string CourseInstanceUuid { get; init; }

        [JsonPropertyName("courseInstanceCode")]
        public string CourseInstanceCode { get; init; }

        [JsonPropertyName("courseInstanceOldCode")]
        public string CourseInstanceOldCode { get; init; }

        [JsonPropertyName("courseName")]
        public string CourseName { get; init; }

        [JsonPropertyName("formCode")]
        public string FormCode { get; init; }

        [JsonPropertyName("formName")]
        public string FormName { get; init; }

        [JsonPropertyName("titleCode")]
        public string TitleCode { get; init; }

        [JsonPropertyName("titleName")]
        public string TitleName { get; init; }

        [JsonPropertyName("languageCode")]
        public string LanguageCode { get; init; }

        [JsonPropertyName("languageName")]
        public string LanguageName { get; init; }

        [JsonPropertyName("philologicalLanguages")]
        public PhilologicalLanguage[] PhilologicalLanguages { get; init; }

        [JsonPropertyName("educationStartDate")]
        public string EducationStartDate { get; init; }

        [JsonPropertyName("numberOfSemesters")]
        public string NumberOfSemesters { get; init; }

        [JsonPropertyName("ects")]
        public string Ects { get; init; }

        [JsonPropertyName("dual")]
        public string Dual { get; init; }

        [JsonPropertyName("bridging")]
        public string Bridging { get; init; }

        [JsonPropertyName("statusCode")]
        public string StatusCode { get; init; }

        [JsonPropertyName("statusName")]
        public string StatusName { get; init; }

        [JsonPropertyName("liquidationDate")]
        public string LiquidationDate { get; init; }

        [JsonPropertyName("coopWithVocational")]
        public string CoopWithVocational { get; init; }
    }
}
