namespace Application.DatabaseRelational.Models.Companies.Statuses
{
    public class CompanyStatus
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        //Dependencies
        public virtual ICollection<CompanyStatusHistory> Histories { get; set; } = new List<CompanyStatusHistory>();
    }
}
