namespace RadonFlatFileDB.Features.Branches.Entities
{
    public class Branch
    {
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
        public string? Wojewodztwo { get; init; } = null!;
        public string AdresUlica { get; init; } = null!;
        public string AdresNumer { get; init; } = null!;
        public string AdresKodPocztowy { get; init; } = null!;
        public string AdresMiasto { get; init; } = null!;
        public IEnumerable<Change> HistoriaZmianNazwy { get; init; } = [];
        public IEnumerable<Change> HistoriaZmianStatusu { get; init; } = [];
        public IEnumerable<Change> HistoriaZmianAdresu { get; init; } = [];
    }
}
