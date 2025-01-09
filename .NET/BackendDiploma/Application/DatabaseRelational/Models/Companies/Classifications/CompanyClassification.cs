using Application.DatabaseRelational.Models.Addresses;

namespace Application.DatabaseRelational.Models.Companies.Classifications
{
    public class CompanyClassification
    {
        //Property
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;

        //Dependencies
        public int CountryId { get; set; }
        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<CompanyClassificationDetail> Classifications { get; set; } = new List<CompanyClassificationDetail>();
    }
}
