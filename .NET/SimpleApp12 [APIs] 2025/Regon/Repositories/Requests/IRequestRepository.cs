using Regon.DTOs.RegonApiResponses;
using Regon.Enums;
using Regon.ValueObjects;
using System.Xml.Linq;

namespace Regon.Repositories.Requests
{
    public interface IRequestRepository
    {
        Task<SessionId?> ZalogujAsync(UserKey key, CancellationToken cancellation,
            bool isProduction = true);
        Task<bool> WylogujAsync(SessionId session, CancellationToken cancellation,
            bool isProduction = true);
        Task<DaneSzukaj> DaneSzukajAsync(SessionId session, DaneSzukajEnum szukajZa,
            string dane, CancellationToken cancellation, bool isProduction = true);
        Task<string> GetValueAsync(SessionId? session, GetValueEnum type, CancellationToken cancellation,
            bool isProduction = true);
        Task<XElement?> DanePobierzPelnyRaport(SessionId session, string regon,
            PelnyRaportEnum nazwaRaportu, CancellationToken cancellation, bool isProduction = true);
    }
}
