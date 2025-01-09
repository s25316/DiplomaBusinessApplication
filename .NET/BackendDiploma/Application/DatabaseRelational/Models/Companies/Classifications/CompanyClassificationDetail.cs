namespace Application.DatabaseRelational.Models.Companies.Classifications
{
    public class CompanyClassificationDetail
    {
        //Properties
        public bool IsMain { get; set; }

        //Dependencies
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;
        public int CompanyClassificationId { get; set; }
        public CompanyClassification CompanyClassification { get; set; } = null!;
    }
}
