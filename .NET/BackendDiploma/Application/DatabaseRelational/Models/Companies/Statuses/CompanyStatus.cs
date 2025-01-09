namespace Application.DatabaseRelational.Models.Companies.Statuses
{
    public class CompanyStatus
    {
        //Properties
        public int CompanyStatusId { get; set; }
        public string Name { get; set; } = null!;

        //Dependencies
        public virtual ICollection<CompanyStatusHistory> CompanyStatusHistories { get; set; } = new List<CompanyStatusHistory>();
    }
}
