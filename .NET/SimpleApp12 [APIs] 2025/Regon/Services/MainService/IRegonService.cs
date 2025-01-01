using Regon.DTOs.ThisAppResponses;

namespace Regon.Services.MainService
{
    public interface IRegonService
    {
        Task<StatusUslugiResponse> StatusUslugiAsync(CancellationToken cancellation,
            bool isProduction = true);

        Task<DaneSzukajResponse> DaneSzukajAsync(
            string key,
            string value,
            string typeValue,
            CancellationToken cancellation,
            bool isProduction = true);
        Task<PelnyRaportResponse> DanePobierzPelnyRaportAsync(
            string key,
            string value,
            string typeValue,
            CancellationToken cancellation,
            bool isProduction = true);

        Task<PelnyRaportResponse> RaportDzialalnosciPkdAsync(
            string key,
            string value,
            string typeValue,
            CancellationToken cancellation,
            bool isProduction = true);
    }
}
