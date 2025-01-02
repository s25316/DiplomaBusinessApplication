using Regon.DTOs.RegonApiResponses;
using System.Text.RegularExpressions;

namespace Regon.DTOs.ThisAppResponses
{
    public class DaneSzukajResponse
    {
        public string Regon { get; init; } = null!;
        public string Nazwa { get; init; } = null!;
        public string? Wojewodztwo { get; init; } = null;
        public string? Powiat { get; init; } = null;
        public string? Gmina { get; init; } = null;
        public string? Miejscowosc { get; init; } = null;
        public string? KodPocztowy { get; init; } = null;
        public string TypKod { get; init; } = null!;
        public string TypNazwa { get; init; } = null!;
        public int SilosID { get; init; } = -1;

        //=============================================================================================
        //=============================================================================================
        //=============================================================================================
        //Public Methods
        public static implicit operator DaneSzukajResponse(DaneSzukaj d)
        {
            var regex = new Regex(@"^\d{9}00000$");
            var regon = regex.IsMatch(d.Regon) ?
                d.Regon.Remove(14 - 5) :
                d.Regon;
            return new DaneSzukajResponse
            {
                Regon = regon,
                Nazwa = d.Nazwa,
                Wojewodztwo = NullOrWhiteSpace(d.Wojewodztwo),
                Powiat = NullOrWhiteSpace(d.Powiat),
                Gmina = NullOrWhiteSpace(d.Gmina),
                Miejscowosc = NullOrWhiteSpace(d.Miejscowosc),
                KodPocztowy = NullOrWhiteSpace(d.KodPocztowy),
                TypKod = d.Typ,
                TypNazwa = TypName(d.Typ),
                SilosID = d.SilosID,
            };
        }
        //=============================================================================================
        //=============================================================================================
        //=============================================================================================
        //Private Methods
        private static string? NullOrWhiteSpace(string? value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }
        private static string TypName(string code)
        {
            switch (code.Trim().ToUpper())
            {
                case "LF":
                    return Messages.DaneSzukajResponse_LF;
                case "LP":
                    return Messages.DaneSzukajResponse_LP;
                case "F":
                    return Messages.DaneSzukajResponse_F;
                default:
                    return Messages.DaneSzukajResponse_P;
            }
        }
    }
}
