using Regon.Enums;
using Regon.ValueObjects;

namespace Regon.Services.EnvelopesForRequest
{
    public interface IRequestEnvelopes
    {
        string GetEndpoint(bool isProduction = true);
        string Wyloguj(SessionId session, bool isProduction = true);
        string Zaloguj(UserKey key, bool isProduction = true);
        string DaneSzukaj(DaneSzukajEnum szukajZa, string dane, bool isProduction = true);
        string GetValue(GetValueEnum type, bool isProduction = true);
        string PobierzPelnyRaport(string regon, PelnyRaportEnum nazwaRaportu, bool isProduction = true);
    }
}
