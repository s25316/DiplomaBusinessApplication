namespace RadonFlatFileDB.Features.DoctoralSchools
{
    public record DoctoralSchoolPair
    {
        //Properties
        public Guid Id { get; init; }
        public Guid PodmiotProwadzącyId { get; init; }
    }
}
