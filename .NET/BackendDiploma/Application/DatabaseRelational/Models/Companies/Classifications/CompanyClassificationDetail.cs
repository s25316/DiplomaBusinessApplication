namespace Application.DatabaseRelational.Models.Companies.Classifications
{
    public class CompanyClassificationDetail
    {
        //Properties
        public bool IsMain { get; set; }

        //Dependencies
        public Guid CompanyId { get; set; }
        public Company Company { get; set; } = null!;
        public int ClassificationId { get; set; }
        public CompanyClassification Classification { get; set; } = null!;
    }
}
