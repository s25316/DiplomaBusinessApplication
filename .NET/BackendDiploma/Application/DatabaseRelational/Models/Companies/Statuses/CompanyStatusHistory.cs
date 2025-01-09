namespace Application.DatabaseRelational.Models.Companies.Statuses
{
    public class CompanyStatusHistory
    {
        //Properties
        public DateOnly Date { get; set; }

        //Dependencies
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = null!;
        public int CompanyStatusId { get; set; }
        public virtual CompanyStatus CompanyStatus { get; set; } = null!;
    }
}
