using System;
using System.Collections.Generic;

namespace ConsoleApp1__Seeding_DB_.Database;

public partial class Street
{
    public int StreetId { get; set; }

    public int CountryId { get; set; }

    public int? DivisionTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Country Country { get; set; } = null!;

    public virtual DivisionType? DivisionType { get; set; }

    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();
}
