using System.Text.Json.Serialization;

namespace Radon.DTOs.ApiResponses.Institutions.Level1
{
    public class Branch
    {
        [JsonPropertyName("branchUuid")]
        public Guid BranchUuid { get; init; }

        [JsonPropertyName("branchName")]
        public string BranchName { get; init; } = null!;

        [JsonPropertyName("branchCity")]
        public string BranchCity { get; init; } = null!;
    }
}
