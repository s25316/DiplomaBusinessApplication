using Regon.DTOs.ThisAppResponses;

namespace Regon.Services.MainService
{
    public interface IRegonService
    {
        Task<StatusUslugiResponse> StatusUslugiAsync(CancellationToken cancellation,
            bool isProduction = true);

        Task<Response<DaneSzukajResponse>> DaneSzukajAsync(
            string key,
            string value,
            string typeValue,
            CancellationToken cancellation,
            bool isProduction = true);
        Task<Response<ReportFullResponse>> DanePobierzPelnyRaportAsync(
            string key,
            string value,
            string typeValue,
            CancellationToken cancellation,
            bool isProduction = true);

        Task<Response<IEnumerable<PkdResponse>>> RaportDzialalnosciPkdAsync(
            string key,
            string value,
            string typeValue,
            CancellationToken cancellation,
            bool isProduction = true);

        Task<Response<ReportFullWithPkdResponse>> DanePobierzPelnyRaportZPkdAsync(
           string key,
           string value,
           string typeValue,
           CancellationToken cancellation,
           bool isProduction = true);
    }
}
