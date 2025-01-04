using Radon.DTOs.ApiResponses.Institutions.Level1;
using Radon.DTOs.ApiResponses.Shared;
using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Institutions
{
    public class Institution
    {
        [JsonPropertyName("institutionUuid")]
        public Guid InstitutionUuid { get; set; }

        [JsonPropertyName("institutionUid")]
        public string InstitutionUid { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("iKindCd")]
        public string IKindCd { get; set; }

        [JsonPropertyName("iKindName")]
        public string IKindName { get; set; }

        [JsonPropertyName("uTypeCd")]
        public string UTypeCd { get; set; }

        [JsonPropertyName("uTypeName")]
        public string UTypeName { get; set; }

        [JsonPropertyName("siTypeCd")]
        public string? SiTypeCd { get; set; }

        [JsonPropertyName("siTypeName")]
        public string? SiTypeName { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("supervisingInstitutionID")]
        public Guid SupervisingInstitutionID { get; set; }

        [JsonPropertyName("supervisingInstitutionName")]
        public string SupervisingInstitutionName { get; set; }

        [JsonPropertyName("countryCd")]
        public string CountryCd { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("voivodeship")]
        public string Voivodeship { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("postalCd")]
        public string PostalCd { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("bNumber")]
        public string BNumber { get; set; }

        [JsonPropertyName("lNumber")]
        public string? LNumber { get; set; }

        [JsonPropertyName("regon")]
        public string Regon { get; set; }

        [JsonPropertyName("nip")]
        public string Nip { get; set; }

        [JsonPropertyName("krs")]
        public string? Krs { get; set; }

        [JsonPropertyName("iStartDT")]
        public string IStartDT { get; set; }

        [JsonPropertyName("iLiqStartDT")]
        public string ILiqStartDT { get; set; }

        [JsonPropertyName("iLiqDT")]
        public string ILiqDT { get; set; }

        [JsonPropertyName("www")]
        public string Www { get; set; }

        [JsonPropertyName("eMail")]
        public string EMail { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("pib")]
        public string Pib { get; set; }

        [JsonPropertyName("yearPib")]
        public string YearPib { get; set; }

        [JsonPropertyName("statusCode")]
        public string StatusCode { get; set; }

        [JsonPropertyName("voivodeshipCode")]
        public string VoivodeshipCode { get; set; }

        [JsonPropertyName("branches")]
        public List<Branch> Branches { get; set; }

        [JsonPropertyName("managerName")]
        public string ManagerName { get; set; }

        [JsonPropertyName("managerSurname")]
        public string ManagerSurname { get; set; }

        [JsonPropertyName("managerOtherNames")]
        public string ManagerOtherNames { get; set; }

        [JsonPropertyName("managerSurnamePrefix")]
        public string ManagerSurnamePrefix { get; set; }

        [JsonPropertyName("managerEmployeeInInstitutionUuid")]
        public string ManagerEmployeeInInstitutionUuid { get; set; }

        [JsonPropertyName("managerFunction")]
        public string ManagerFunction { get; set; }

        [JsonPropertyName("espAddress")]
        public string EspAddress { get; set; }

        [JsonPropertyName("panNumber")]
        public string PanNumber { get; set; }

        [JsonPropertyName("ministryNumber")]
        public string MinistryNumber { get; set; }

        [JsonPropertyName("eunNumber")]
        public string EunNumber { get; set; }

        [JsonPropertyName("federationNumber")]
        public string FederationNumber { get; set; }

        [JsonPropertyName("federationComposition")]
        public List<FederationComposition> FederationComposition { get; set; } = new();

        [JsonPropertyName("transformedInstitutions")]
        public List<TransformedInstitutionDto> TransformedInstitutions { get; set; } = new();

        [JsonPropertyName("targetInstitutions")]
        public List<TargetInstitutionDto> TargetInstitutions { get; set; } = new();

        [JsonPropertyName("names")]
        public List<NameDto> Names { get; set; } = new();

        [JsonPropertyName("supervisingInstitutions")]
        public List<SupervisingInstitution> SupervisingInstitutions { get; set; } = new();

        [JsonPropertyName("statuses")]
        public List<StatusDto> Statuses { get; set; } = new();

        [JsonPropertyName("types")]
        public List<TypeDto> Types { get; set; } = new();

        [JsonPropertyName("addresses")]
        public List<AddressDto> Addresses { get; set; } = new();

        [JsonPropertyName("dataSource")]
        public string DataSource { get; set; }

        [JsonPropertyName("lastRefresh")]
        public string LastRefresh { get; set; }
    }
}
