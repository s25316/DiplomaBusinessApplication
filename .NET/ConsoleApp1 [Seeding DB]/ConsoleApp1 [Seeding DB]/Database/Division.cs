using System;
using System.Collections.Generic;

namespace ConsoleApp1__Seeding_DB_.Database;

public partial class Division
{
    public int DivisionId { get; set; }

    public int? ParentDivisionId { get; set; }

    public int CountryId { get; set; }

    public int DivisionTypeId { get; set; }

    public string Name { get; set; } = null!;

    public int Level { get; set; }

    public string? ParentsPath { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Country Country { get; set; } = null!;

    public virtual DivisionType DivisionType { get; set; } = null!;

    public virtual ICollection<Division> InverseParentDivision { get; set; } = new List<Division>();

    public virtual Division? ParentDivision { get; set; }

    public virtual ICollection<Street> Streets { get; set; } = new List<Street>();
}
