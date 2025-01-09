using Application.DatabaseRelational.Models.Addresses;

namespace Application.DatabaseRelational.Models.Companies.Identifiers
{
    public class CompanyIdentifier
    {
        //Properties
        public int Id { get; set; }
        public string ShortName { get; set; } = null!;
        public string Name { get; set; } = null!;

        //Dependencies
        public int CountryId { get; set; }
        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<CompanyIdentifierDetail> Identifiers { get; set; } = new List<CompanyIdentifierDetail>();
    }
}
