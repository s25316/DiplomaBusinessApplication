using Regon.DTOs.RegonApiResponses;

namespace Regon.DTOs.ThisAppResponses
{
    public class DaneSzukajResponse
    {
        public bool IsActiveService { get; init; } = true;
        public bool IsValidUserKey { get; init; } = false;
        public bool IsSuccess { get; init; } = false;
        public KomunikatKodResponse? InputProblem { get; init; } = null;
        public DaneSzukaj? Result { get; init; } = null;
    }
}
