using RadonFlatFileDB.DTOs.Interfaces;

namespace RadonFlatFileDB.DTOs
{
    public class BranchDto : IFactory<BranchDto>
    {
        //Static Properties 
        private static readonly int _Lp = 0;
        private static readonly int _Id = 1;
        private static readonly int _NazwaFilii = 2;
        private static readonly int _IdInstytucjiGlownej = 3;
        private static readonly int _NazwaInstytucjiGlownej = 4;
        private static readonly int _DataUtworzenia = 5;
        private static readonly int _Status = 6;
        private static readonly int _DataPostawieniaWStanLikwidacji = 7;
        private static readonly int _DataLikwidacji = 8;
        private static readonly int _REGON = 9;
        private static readonly int _NIP = 10;
        private static readonly int _KRS = 11;
        private static readonly int _StronaWWW = 12;
        private static readonly int _AdresEmail = 13;
        private static readonly int _Telefon = 14;
        private static readonly int _AdresSkrzynkiPodawczej = 15;
        private static readonly int _Kraj = 16;
        private static readonly int _Wojewodztwo = 17;
        private static readonly int _AdresUlica = 18;
        private static readonly int _AdresNumer = 19;
        private static readonly int _AdresKodPocztowy = 20;
        private static readonly int _AdresMiasto = 21;
        private static readonly int _HistoriaZmianNazwyNazwa = 22;
        private static readonly int _HistoriaZmianNazwyDataNadaniaNazwy = 23;
        private static readonly int _HistoriaZmianStatusuStatus = 24;
        private static readonly int _HistoriaZmianStatusuDataNadaniaStatusu = 25;
        private static readonly int _HistoriaZmianAdresuAdres = 26;
        private static readonly int _HistoriaZmianAdresuDataOtrzymaniaAdresu = 27;

        //Properties
        public Guid Id { get; init; }
        public string NazwaFilii { get; init; } = null!;
        public Guid IdInstytucjiGlownej { get; init; }
        public DateOnly DataUtworzenia { get; init; }
        public DateOnly? DataPostawieniaWStanLikwidacji { get; init; } = null!;
        public DateOnly? DataLikwidacji { get; init; } = null!;
        public string? StronaWWW { get; init; } = null!;
        public string? AdresEmail { get; init; } = null!;
        public string? Telefon { get; init; } = null!;
        public string Kraj { get; init; } = null!;
        public string? Wojewodztwo { get; init; } = null;
        public string AdresUlica { get; init; } = null!;
        public string AdresNumer { get; init; } = null!;
        public string AdresKodPocztowy { get; init; } = null!;
        public string AdresMiasto { get; init; } = null!;
        public string? HistoriaZmianNazwyNazwa { get; init; } = null!;
        public DateOnly? HistoriaZmianNazwyDataNadaniaNazwy { get; init; } = null!;
        public string? HistoriaZmianStatusuStatus { get; init; } = null!;
        public DateOnly? HistoriaZmianStatusuDataNadaniaStatusu { get; init; } = null!;
        public string? HistoriaZmianAdresuAdres { get; init; } = null!;
        public DateOnly? HistoriaZmianAdresuDataOtrzymaniaAdresu { get; init; } = null!;


        //=================================================================================================
        //=================================================================================================
        //=================================================================================================
        //Public Methods
        public static implicit operator BranchDto(string[] table)
        {
            return new BranchDto
            {
                Id = ParseToGuid(table[_Id]),
                NazwaFilii = table[_NazwaFilii],
                IdInstytucjiGlownej = ParseToGuid(table[_IdInstytucjiGlownej]),
                DataUtworzenia = DateOnly.Parse(table[_DataUtworzenia]),
                DataPostawieniaWStanLikwidacji = ParseToDateOnly(table[_DataPostawieniaWStanLikwidacji]),
                DataLikwidacji = ParseToDateOnly(table[_DataLikwidacji]),
                StronaWWW = ParseToString(table[_StronaWWW]),
                AdresEmail = ParseToString(table[_AdresEmail]),
                Telefon = ParseToString(table[_Telefon]),
                Kraj = table[_Kraj],
                Wojewodztwo = ParseToString(table[_Wojewodztwo]),
                AdresUlica = table[_AdresUlica],
                AdresNumer = table[_AdresNumer],
                AdresKodPocztowy = table[_AdresKodPocztowy],
                AdresMiasto = table[_AdresMiasto],
                HistoriaZmianNazwyNazwa = ParseToString(table[_HistoriaZmianNazwyNazwa]),
                HistoriaZmianNazwyDataNadaniaNazwy = ParseToDateOnly(table[_HistoriaZmianNazwyDataNadaniaNazwy]),
                HistoriaZmianStatusuStatus = ParseToString(table[_HistoriaZmianStatusuStatus]),
                HistoriaZmianStatusuDataNadaniaStatusu = ParseToDateOnly(table[_HistoriaZmianStatusuDataNadaniaStatusu]),
                HistoriaZmianAdresuAdres = ParseToString(table[_HistoriaZmianAdresuAdres]),
                HistoriaZmianAdresuDataOtrzymaniaAdresu = ParseToDateOnly(table[_HistoriaZmianAdresuDataOtrzymaniaAdresu]),
            };
        }

        public BranchDto Create(string[] args)
        {
            return (BranchDto)args;
        }
        //=================================================================================================
        //=================================================================================================
        //=================================================================================================
        //Private Methods
        private static Guid ParseToGuid(string value) => Guid.Parse(value);
        private static string? ParseToString(string? value) =>
            string.IsNullOrWhiteSpace(value) ? null : value;
        private static DateOnly? ParseToDateOnly(string? value) =>
            string.IsNullOrWhiteSpace(value) ? null : DateOnly.FromDateTime(DateTime.Parse(value));

    }
}
