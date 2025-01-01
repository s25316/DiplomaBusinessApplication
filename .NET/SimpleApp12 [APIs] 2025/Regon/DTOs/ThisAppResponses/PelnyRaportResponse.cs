namespace Regon.DTOs.ThisAppResponses
{
    public class PelnyRaportResponse
    {
        public bool IsActiveService { get; init; } = true;
        public bool IsValidUserKey { get; init; } = false;
        public bool IsSuccess { get; init; } = false;
        public KomunikatKodResponse? InputProblem { get; init; } = null;
        public string? Result { get; init; } = null;
        public object? ResultDane { get; init; } = null;
    }
}
