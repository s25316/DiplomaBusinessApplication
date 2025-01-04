using Radon.DTOs.ApiResponses.DoctoralSchools.Level1;
using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.DoctoralSchools
{
    public class DoctoralSchoolDto
    {
        [JsonPropertyName("doctoralSchoolUuid")]
        public string DoctoralSchoolUuid { get; init; }

        [JsonPropertyName("doctoralSchoolCode")]
        public int DoctoralSchoolCode { get; init; }

        [JsonPropertyName("doctoralSchoolName")]
        public string DoctoralSchoolName { get; init; }

        [JsonPropertyName("creationDate")]
        public string CreationDate { get; init; }

        [JsonPropertyName("responsibleInstitutionUuid")]
        public string ResponsibleInstitutionUuid { get; init; }

        [JsonPropertyName("responsibleInstitutionName")]
        public string ResponsibleInstitutionName { get; init; }

        [JsonPropertyName("coLeadingInstitutions")]
        public List<CoLeadingInstitution> CoLeadingInstitutions { get; init; }

        [JsonPropertyName("disciplines")]
        public List<Discipline> Disciplines { get; init; }

        [JsonPropertyName("educationStopDate")]
        public string EducationStopDate { get; init; }

        [JsonPropertyName("statusCode")]
        public int StatusCode { get; init; }

        [JsonPropertyName("statusName")]
        public string StatusName { get; init; }

        [JsonPropertyName("programs")]
        public List<Program> Programs { get; init; }

        [JsonPropertyName("countryCd")]
        public string CountryCd { get; init; }

        [JsonPropertyName("country")]
        public string Country { get; init; }

        [JsonPropertyName("voivodeship")]
        public string Voivodeship { get; init; }

        [JsonPropertyName("voivodeshipCode")]
        public string VoivodeshipCode { get; init; }

        [JsonPropertyName("city")]
        public string City { get; init; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; init; }

        [JsonPropertyName("street")]
        public string Street { get; init; }

        [JsonPropertyName("buildingNumber")]
        public string BuildingNumber { get; init; }

        [JsonPropertyName("apartmentNumber")]
        public string ApartmentNumber { get; init; }

        [JsonPropertyName("www")]
        public string Www { get; init; }

        [JsonPropertyName("eMail")]
        public string EMail { get; init; }

        [JsonPropertyName("dataSource")]
        public string DataSource { get; init; }

        [JsonPropertyName("lastRefresh")]
        public string LastRefresh { get; init; }
    }
}
