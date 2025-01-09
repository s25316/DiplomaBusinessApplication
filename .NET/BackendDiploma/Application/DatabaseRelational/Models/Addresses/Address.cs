namespace Application.DatabaseRelational.Models.Addresses
{
    public class Address
    {
        //Properties
        public Guid AddressId { get; set; }
        public string BuildingNumber { get; set; } = null!;
        public string? ApartmentNumber { get; set; } = null;
        public string? ZipCode { get; set; } = null;

        //Dependencies
        public int? StreetId { get; set; } = null;
        public virtual Street? Street { get; set; } = null;
        public int DivisionId { get; set; }
        public virtual Division Division { get; set; } = null!;
    }
}
