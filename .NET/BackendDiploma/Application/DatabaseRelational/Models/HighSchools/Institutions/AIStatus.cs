namespace Application.DatabaseRelational.Models.HighSchools.Institutions
{
    public class AIStatus
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //Dependencies
        public virtual ICollection<AIStatusHistory> Histories { get; set; } = new List<AIStatusHistory>();
    }
}
