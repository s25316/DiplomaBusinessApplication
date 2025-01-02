using Regon.DTOs.RegonApiResponses.Raporty.Pelny;
using System.Text.RegularExpressions;

namespace Regon.DTOs.ThisAppResponses
{
    public class ReportFullResponse
    {
        public string Regon { get; init; } = null!;
        public string Nazwa { get; init; } = null!;
        public string? Nip { get; init; } = null;
        public string? NazwaSkrocona { get; init; } = null;
        public string? AdSiedzKrajSymbol { get; init; } = null;
        public string? AdSiedzWojewodztwoSymbol { get; init; } = null;
        public string? AdSiedzPowiatSymbol { get; init; } = null;
        public string? AdSiedzGminaSymbol { get; init; } = null;
        public string? AdSiedzKodPocztowy { get; init; } = null;
        public string? AdSiedzMiejscowoscPocztySymbol { get; init; } = null;
        public string? AdSiedzMiejscowoscSymbol { get; init; } = null;
        public string? AdSiedzUlicaSymbol { get; init; } = null;
        public string? AdSiedzNumerNieruchomosci { get; init; } = null;
        public string? AdSiedzNumerLokalu { get; init; } = null;
        public string? AdSiedNietypoweMiejsceLokalizacji { get; init; } = null;
        public string? AdSiedKrajNazwa { get; init; } = null;
        public string? AdSiedWojewodztwoNazwa { get; init; } = null;
        public string? AdSiedPowiatNazwa { get; init; } = null;
        public string? AdSiedGminaNazwa { get; init; } = null;
        public string? AdSiedMiejscowoscPocztyNazwa { get; init; } = null;
        public string? AdSiedMiejscowoscNazwa { get; init; } = null;
        public string? AdSiedUlicaNazwa { get; init; } = null;
        public string[] NumerTelefonu { get; init; } = Array.Empty<string>();
        public string[] NumerWewnetrznyTelefonu { get; init; } = Array.Empty<string>();
        public string[] NumerFaksu { get; init; } = Array.Empty<string>();
        public string[] AdresEmail { get; init; } = Array.Empty<string>();
        public string[] WWW { get; init; } = Array.Empty<string>();
        public DateOnly DataPowstania { get; init; }
        public DateOnly DataRozpoczeciaDzialalnosci { get; init; }
        public DateOnly? DataWpisuDoREGON { get; init; } = null;
        public DateOnly? DataZawieszenia { get; init; } = null;
        public DateOnly? DataWznowienia { get; init; } = null;
        public DateOnly? DataZaistnieniaZmiany { get; init; } = null;
        public DateOnly? DataZakonczenia { get; init; } = null;
        public DateOnly? DataSkreslenia { get; init; } = null;
        public DateOnly? DataWpisuDoRejestruEwidencji { get; init; } = null;
        public string? NumerwRejestrzeEwidencji { get; init; } = null;
        public string? OrganRejestrowySymbol { get; init; } = null;
        public string? OrganRejestrowyNazwa { get; init; } = null;
        public string? RodzajRejestruSymbol { get; init; } = null;
        public string RodzajRejestruNazwa { get; init; } = null!;
        public string? FormaFinansowaniaSymbol { get; init; } = null;
        public string? FormaFinansowaniaNazwa { get; init; } = null;
        public string? PodstawowaFormaPrawnaSymbol { get; init; } = null;
        public string? PodstawowaFormaPrawnaNazwa { get; init; } = null;
        public string? SzczegolnaFormaPrawnaSymbol { get; init; } = null;
        public string? SzczegolnaFormaPrawnaNazwa { get; init; } = null;
        public string? OrganZalozycielskiSymbol { get; init; } = null;
        public string? OrganZalozycielskiNazwa { get; init; } = null;
        public string? FormaWlasnosciSymbol { get; init; } = null;
        public string? FormaWlasnosciNazwa { get; init; } = null;


        //========================================================================================================
        //========================================================================================================
        //========================================================================================================
        //Public Methods
        public static implicit operator ReportFullResponse(ReportFull r)
        {
            var regex = new Regex(@"^\d{9}00000$");
            var regon = regex.IsMatch(r.Regon) ?
                r.Regon.Remove(14 - 5) :
                r.Regon;
            return new ReportFullResponse
            {
                Regon = regon,
                Nazwa = r.Nazwa,
                Nip = NullOrWhiteSpace(r.Nip),
                NazwaSkrocona = NullOrWhiteSpace(r.NazwaSkrocona),
                AdSiedzKrajSymbol = NullOrWhiteSpace(r.AdSiedzKrajSymbol),
                AdSiedzWojewodztwoSymbol = NullOrWhiteSpace(r.AdSiedzWojewodztwoSymbol),
                AdSiedzPowiatSymbol = NullOrWhiteSpace(r.AdSiedzPowiatSymbol),
                AdSiedzGminaSymbol = NullOrWhiteSpace(r.AdSiedzGminaSymbol),
                AdSiedzKodPocztowy = NullOrWhiteSpace(r.AdSiedzKodPocztowy),
                AdSiedzMiejscowoscPocztySymbol = NullOrWhiteSpace(r.AdSiedzMiejscowoscPocztySymbol),
                AdSiedzMiejscowoscSymbol = NullOrWhiteSpace(r.AdSiedzMiejscowoscSymbol),
                AdSiedzUlicaSymbol = NullOrWhiteSpace(r.AdSiedzUlicaSymbol),
                AdSiedzNumerNieruchomosci = NullOrWhiteSpace(r.AdSiedzNumerNieruchomosci),
                AdSiedzNumerLokalu = NullOrWhiteSpace(r.AdSiedzNumerLokalu),
                AdSiedNietypoweMiejsceLokalizacji = NullOrWhiteSpace(r.AdSiedNietypoweMiejsceLokalizacji),
                AdSiedKrajNazwa = NullOrWhiteSpace(r.AdSiedKrajNazwa),
                AdSiedWojewodztwoNazwa = NullOrWhiteSpace(r.AdSiedWojewodztwoNazwa),
                AdSiedPowiatNazwa = NullOrWhiteSpace(r.AdSiedPowiatNazwa),
                AdSiedGminaNazwa = NullOrWhiteSpace(r.AdSiedGminaNazwa),
                AdSiedMiejscowoscPocztyNazwa = NullOrWhiteSpace(r.AdSiedMiejscowoscPocztyNazwa),
                AdSiedMiejscowoscNazwa = NullOrWhiteSpace(r.AdSiedMiejscowoscNazwa),
                AdSiedUlicaNazwa = NullOrWhiteSpace(r.AdSiedUlicaNazwa),
                NumerTelefonu = NullOrWhiteSpace(r.NumerTelefonu),
                NumerWewnetrznyTelefonu = NullOrWhiteSpace(r.NumerWewnetrznyTelefonu),
                NumerFaksu = NullOrWhiteSpace(r.NumerFaksu),
                AdresEmail = NullOrWhiteSpace(r.AdresEmail),
                WWW = NullOrWhiteSpace(r.WWW),
                DataPowstania = DateOnly.Parse(r.DataPowstania),
                DataRozpoczeciaDzialalnosci = DateOnly.Parse(r.DataRozpoczeciaDzialalnosci),
                DataWpisuDoREGON = ParseToDateOnly(r.DataWpisuDoREGON),
                DataZawieszenia = ParseToDateOnly(r.DataZawieszenia),
                DataWznowienia = ParseToDateOnly(r.DataWznowienia),
                DataZaistnieniaZmiany = ParseToDateOnly(r.DataZaistnieniaZmiany),
                DataZakonczenia = ParseToDateOnly(r.DataZakonczenia),
                DataSkreslenia = ParseToDateOnly(r.DataSkreslenia),
                DataWpisuDoRejestruEwidencji = ParseToDateOnly(r.DataWpisuDoRejestruEwidencji),
                NumerwRejestrzeEwidencji = NullOrWhiteSpace(r.NumerwRejestrzeEwidencji),
                OrganRejestrowySymbol = NullOrWhiteSpace(r.OrganRejestrowySymbol),
                OrganRejestrowyNazwa = NullOrWhiteSpace(r.OrganRejestrowyNazwa),
                RodzajRejestruSymbol = NullOrWhiteSpace(r.RodzajRejestruSymbol),
                RodzajRejestruNazwa = r.RodzajRejestruNazwa,
                FormaFinansowaniaSymbol = NullOrWhiteSpace(r.FormaFinansowaniaSymbol),
                FormaFinansowaniaNazwa = NullOrWhiteSpace(r.FormaFinansowaniaNazwa),
                PodstawowaFormaPrawnaSymbol = NullOrWhiteSpace(r.PodstawowaFormaPrawnaSymbol),
                PodstawowaFormaPrawnaNazwa = NullOrWhiteSpace(r.PodstawowaFormaPrawnaNazwa),
                SzczegolnaFormaPrawnaSymbol = NullOrWhiteSpace(r.SzczegolnaFormaPrawnaSymbol),
                SzczegolnaFormaPrawnaNazwa = NullOrWhiteSpace(r.SzczegolnaFormaPrawnaNazwa),
                OrganZalozycielskiSymbol = NullOrWhiteSpace(r.OrganZalozycielskiSymbol),
                OrganZalozycielskiNazwa = NullOrWhiteSpace(r.OrganZalozycielskiNazwa),
                FormaWlasnosciSymbol = NullOrWhiteSpace(r.FormaWlasnosciSymbol),
                FormaWlasnosciNazwa = NullOrWhiteSpace(r.FormaWlasnosciNazwa),
            };
        }

        //========================================================================================================
        //========================================================================================================
        //========================================================================================================
        //Private Methods
        private static string? NullOrWhiteSpace(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }
        private static string[] NullOrWhiteSpace(string[] value)
        {
            return value
                .Where(text => string.IsNullOrWhiteSpace(text) != true)
                .ToArray();
        }

        public static DateOnly? ParseToDateOnly(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            return DateOnly.Parse(value);
        }
    }
}
