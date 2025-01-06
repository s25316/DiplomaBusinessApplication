namespace RadonFiles.Features
{
    public record Change
    {
        public string Value { get; init; } = null!;
        public DateOnly Date { get; init; }
    }
}
