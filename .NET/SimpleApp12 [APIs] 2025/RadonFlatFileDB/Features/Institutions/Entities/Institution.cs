using RadonFlatFileDB.Features.Institutions.ValueObjects;

namespace RadonFlatFileDB.Features.Institutions.Entities
{
    public class Institution
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = null!;
        public DateOnly CreationDate { get; init; }
        public string InstitutionType { get; init; } = null!;
        public bool IsPan { get; init; }
        public int? YearFromPan { get; init; } = null;
        public DateOnly? LiquidationStartDate { get; init; } = null;
        public DateOnly? LiquidationDate { get; init; } = null;
        public string? UniversityType { get; init; } = null;// Tylko jeśli InstitutionType contains Uczelnia
        public string? ScientificInstitutionType { get; init; } = null;
        public string? Regon { get; init; } = null;
        public string? Nip { get; init; } = null;
        public string? Krs { get; init; } = null;
        public string? Website { get; init; } = null;
        public string? Email { get; init; } = null;
        public string? Phone { get; init; } = null;
        public string Country { get; init; } = null!;
        public string Voivodeship { get; init; } = null!;
        public string StreetAddress { get; init; } = null!;
        public string AddressNumber { get; init; } = null!;
        public string PostalCode { get; init; } = null!;
        public string City { get; init; } = null!;
        public IEnumerable<Change> Names { get; init; } = [];
        public IEnumerable<Change> StatusChangeHistory { get; init; } = [];
        public IEnumerable<Change> TypeChangeHistory { get; init; } = [];
        public IEnumerable<Change> AddressChangeHistory { get; init; } = [];
        public IEnumerable<TransformationInstitution> Predecessors { get; init; } = [];
        public IEnumerable<TransformationInstitution> Successors { get; init; } = [];
    }
}
