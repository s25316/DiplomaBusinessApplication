namespace Regon.DTOs.ThisAppResponses
{
    public class ReportFullWithPkdResponse
    {
        public string Type { get; init; } = null!;
        public ReportFullResponse Report { get; init; } = null!;
        public IEnumerable<PkdResponse> Pkd { get; init; } = [];
    }
}
