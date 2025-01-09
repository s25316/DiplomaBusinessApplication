namespace Application.DatabaseRelational.Models.Companies.Statuses
{
    public class CompanyStatusHistory
    {
        //Properties
        public Guid CompanyId { get; set; }
        public int StatusId { get; set; }
        public DateOnly Date { get; set; }

        //Dependencies
        public virtual Company Company { get; set; } = null!;
        public virtual CompanyStatus Status { get; set; } = null!;
    }
}
