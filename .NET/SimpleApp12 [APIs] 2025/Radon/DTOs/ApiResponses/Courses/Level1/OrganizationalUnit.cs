using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Courses.Level1
{
    public class OrganizationalUnit
    {
        [JsonPropertyName("organizationalUnitUuid")]
        public string OrganizationalUnitUuid { get; init; }

        [JsonPropertyName("organizationalUnitFullName")]
        public string OrganizationalUnitFullName { get; init; }
    }
}
