namespace Application.DatabaseRelational.Models.Addresses
{
    public class Street
    {
        public int StreetId { get; set; }
        public string Name { get; set; } = null!;

        //Dependencies
        public int CountryId { get; set; }
        public virtual Country Country { get; set; } = null!;
        public int? DivisionTypeId { get; set; } = null;
        public virtual DivisionType? DivisionType { get; set; } = null;
        public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
