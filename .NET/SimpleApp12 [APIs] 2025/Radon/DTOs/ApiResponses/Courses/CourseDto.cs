using Radon.DTOs.ApiResponses.Courses.Level1;
using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Courses
{
    public class CourseDto
    {
        [JsonPropertyName("courseUuid")]
        public string CourseUuid { get; init; }

        [JsonPropertyName("courseCode")]
        public string CourseCode { get; init; }

        [JsonPropertyName("courseOldCode")]
        public string CourseOldCode { get; init; }

        [JsonPropertyName("courseName")]
        public string CourseName { get; init; }

        [JsonPropertyName("levelCode")]
        public string LevelCode { get; init; }

        [JsonPropertyName("levelName")]
        public string LevelName { get; init; }

        [JsonPropertyName("profileCode")]
        public string ProfileCode { get; init; }

        [JsonPropertyName("profileName")]
        public string ProfileName { get; init; }

        [JsonPropertyName("iscedCode")]
        public string IscedCode { get; init; }

        [JsonPropertyName("iscedName")]
        public string IscedName { get; init; }

        [JsonPropertyName("creationDate")]
        public string CreationDate { get; init; }

        [JsonPropertyName("teacherTraining")]
        public string TeacherTraining { get; init; }

        [JsonPropertyName("philological")]
        public string Philological { get; init; }

        [JsonPropertyName("philologicalLanguages")]
        public List<PhilologicalLanguage> PhilologicalLanguages { get; init; } = new();

        [JsonPropertyName("coLed")]
        public string CoLed { get; init; }

        [JsonPropertyName("coLedDataFrom")]
        public string CoLedDataFrom { get; init; }

        [JsonPropertyName("coLedInterdisciplinary")]
        public string CoLedInterdisciplinary { get; init; }

        [JsonPropertyName("currentStatusCode")]
        public string CurrentStatusCode { get; init; }

        [JsonPropertyName("currentStatusName")]
        public string CurrentStatusName { get; init; }

        [JsonPropertyName("terminationInitializationDate")]
        public string TerminationInitializationDate { get; init; }

        [JsonPropertyName("liquidationDate")]
        public string LiquidationDate { get; init; }

        [JsonPropertyName("disciplines")]
        public List<Discipline> Disciplines { get; init; } = new();

        [JsonPropertyName("leadingInstitutionUuid")]
        public string LeadingInstitutionUuid { get; init; }

        [JsonPropertyName("leadingInstitutionName")]
        public string LeadingInstitutionName { get; init; }

        [JsonPropertyName("leadingInstitutionIsForeign")]
        public string LeadingInstitutionIsForeign { get; init; }

        [JsonPropertyName("leadingInstitutionCity")]
        public string LeadingInstitutionCity { get; init; }

        [JsonPropertyName("leadingInstitutionVoivodeship")]
        public string LeadingInstitutionVoivodeship { get; init; }

        [JsonPropertyName("leadingInstitutionVoivodeshipCode")]
        public string LeadingInstitutionVoivodeshipCode { get; init; }

        [JsonPropertyName("mainInstitutionUuid")]
        public string MainInstitutionUuid { get; init; }

        [JsonPropertyName("mainInstitutionName")]
        public string MainInstitutionName { get; init; }

        [JsonPropertyName("mainInstitutionKind")]
        public string MainInstitutionKind { get; init; }

        [JsonPropertyName("mainInstitutionKindCode")]
        public string MainInstitutionKindCode { get; init; }

        [JsonPropertyName("supervisingInstitutionUuid")]
        public string SupervisingInstitutionUuid { get; init; }

        [JsonPropertyName("supervisingInstitutionName")]
        public string SupervisingInstitutionName { get; init; }

        [JsonPropertyName("coLeadingInstitutions")]
        public List<CoLeadingInstitution> CoLeadingInstitutions { get; init; } = new();

        [JsonPropertyName("organizationalUnits")]
        public List<OrganizationalUnit> OrganizationalUnits { get; init; } = new();

        [JsonPropertyName("legalBasisTypeCode")]
        public string LegalBasisTypeCode { get; init; }

        [JsonPropertyName("legalBasisTypeName")]
        public string LegalBasisTypeName { get; init; }

        [JsonPropertyName("legalBasisNumber")]
        public string LegalBasisNumber { get; init; }

        [JsonPropertyName("legalBasisDate")]
        public string LegalBasisDate { get; init; }

        [JsonPropertyName("courseInstances")]
        public List<CourseInstance> CourseInstances { get; init; } = new();

        [JsonPropertyName("dataSource")]
        public string DataSource { get; init; }

        [JsonPropertyName("lastRefresh")]
        public string LastRefresh { get; init; }
    }
}
