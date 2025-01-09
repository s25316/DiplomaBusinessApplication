namespace Application.DatabaseRelational.Models.Companies.Identifiers
{
    public class CompanyIdentifierDetail
    {
        //Properties
        public string Value { get; set; } = null!;

        //Dependencies
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; } = null!;
        public int IdentifierId { get; set; }
        public virtual CompanyIdentifier Identifier { get; set; } = null!;
    }
}
