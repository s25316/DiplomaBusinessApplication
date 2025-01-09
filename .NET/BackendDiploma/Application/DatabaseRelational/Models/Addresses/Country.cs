using Application.DatabaseRelational.Models.Companies.Classifications;
using Application.DatabaseRelational.Models.Companies.Identifiers;

namespace Application.DatabaseRelational.Models.Addresses
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;

        //Dependencies
        public virtual ICollection<Street> Streets { get; set; } = new List<Street>();
        public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();
        public virtual ICollection<CompanyIdentifier> CompanyIdentifierTypes { get; set; } = new List<CompanyIdentifier>();
        public virtual ICollection<CompanyClassification> CompanyClassificationTypes { get; set; } = new List<CompanyClassification>();
    }
}
