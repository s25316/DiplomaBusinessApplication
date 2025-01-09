using Application.DatabaseRelational.Models.Addresses;

namespace Application.DatabaseRelational.Models.Companies.Identifiers
{
    public class CompanyIdentifier
    {
        //Properties
        public int CompanyIdentifierId { get; set; }
        public string ShortName { get; set; } = null!;
        public string Name { get; set; } = null!;

        //Dependencies
        public int CountryId { get; set; }
        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<CompanyIdentifierDetail> CompanyIdentifiers { get; set; } = new List<CompanyIdentifierDetail>();
    }
}
