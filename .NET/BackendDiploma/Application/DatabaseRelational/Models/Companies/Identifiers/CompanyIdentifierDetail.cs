namespace Application.DatabaseRelational.Models.Companies.Identifiers
{
    public class CompanyIdentifierDetail
    {
        //Properties
        public string Value { get; set; } = null!;

        //Dependencies
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = null!;
        public int CompanyIdentifierId { get; set; }
        public virtual CompanyIdentifier CompanyIdentifier { get; set; } = null!;
    }
}
