namespace Regon.DTOs.ThisAppResponses
{
    public class StatusUslugiResponse
    {
        public bool IsActive { get; init; } = false;
        public string? Status { get; init; }
        public string? Message { get; init; }
    }
}
