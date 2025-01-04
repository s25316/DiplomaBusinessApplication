using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Institutions.Level1
{
    public class TypeDto
    {
        [JsonPropertyName("typeName")]
        public string TypeName { get; set; } = null!;

        [JsonPropertyName("dateFrom")]
        public string DateFrom { get; set; } = null!;
    }
}
