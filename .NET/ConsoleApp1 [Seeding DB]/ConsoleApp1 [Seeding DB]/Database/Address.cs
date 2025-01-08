using System;
using System.Collections.Generic;

namespace ConsoleApp1__Seeding_DB_.Database;

public partial class Address
{
    public Guid AddressId { get; set; }

    public int? StreetId { get; set; }

    public int DivisionId { get; set; }

    public string BuildingNumber { get; set; } = null!;

    public string? ApartmentNumber { get; set; }

    public virtual Division Division { get; set; } = null!;

    public virtual Street? Street { get; set; }
}
