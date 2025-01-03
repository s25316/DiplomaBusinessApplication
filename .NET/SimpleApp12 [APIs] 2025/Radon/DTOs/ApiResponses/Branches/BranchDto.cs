﻿using Radon.DTOs.ApiResponses.Shared;
using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Branches
{
    public class BranchDto
    {
        [JsonPropertyName("branchUuid")]
        public Guid BranchUuid { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("mainInstitutionUuid")]
        public string MainInstitutionUuid { get; init; }

        [JsonPropertyName("mainInstitutionName")]
        public string MainInstitutionName { get; init; }

        [JsonPropertyName("creationDate")]
        public string CreationDate { get; init; }

        [JsonPropertyName("statusCode")]
        public string StatusCode { get; init; }

        [JsonPropertyName("status")]
        public string Status { get; init; }

        [JsonPropertyName("liquidationStartDate")]
        public string LiquidationStartDate { get; init; }

        [JsonPropertyName("liquidationDate")]
        public string LiquidationDate { get; init; }

        [JsonPropertyName("regon")]
        public string Regon { get; init; }

        [JsonPropertyName("nip")]
        public string Nip { get; init; }

        [JsonPropertyName("krs")]
        public string Krs { get; init; }

        [JsonPropertyName("www")]
        public string Www { get; init; }

        [JsonPropertyName("eMail")]
        public string Email { get; init; }

        [JsonPropertyName("phone")]
        public string Phone { get; init; }

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

        [JsonPropertyName("espAddress")]
        public string EspAddress { get; init; }

        [JsonPropertyName("names")]
        public List<NameDto> Names { get; init; }

        [JsonPropertyName("statuses")]
        public List<StatusDto> Statuses { get; init; }

        [JsonPropertyName("addresses")]
        public List<AddressDto> Addresses { get; init; }

        [JsonPropertyName("dataSource")]
        public string DataSource { get; init; }

        [JsonPropertyName("lastRefresh")]
        public string LastRefresh { get; init; }
    }
}
