namespace Application.DatabaseRelational.Models.HighSchools.Institutions.SpecificTypes
{
    public class AISpecificType
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //Dependencies
        public virtual ICollection<AISpecificTypeHistory> Histories { get; set; } = new List<AISpecificTypeHistory>();
    }
}
