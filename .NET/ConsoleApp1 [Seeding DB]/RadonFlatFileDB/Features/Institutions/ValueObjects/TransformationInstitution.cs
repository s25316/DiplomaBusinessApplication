namespace RadonFlatFileDB.Features.Institutions.ValueObjects
{
    public record TransformationInstitution
    {
        public Guid Id { get; init; }
        public string TransformationType { get; init; } = null!;
        public DateOnly Date { get; init; }
    }
}
