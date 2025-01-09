namespace Application.DatabaseRelational.Models.Companies
{
    public class CompanyNameHistory

    {
        //Properties
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly Date { get; set; }

        //Dependencies
        public virtual Company Company { get; set; } = null!;
    }
}
