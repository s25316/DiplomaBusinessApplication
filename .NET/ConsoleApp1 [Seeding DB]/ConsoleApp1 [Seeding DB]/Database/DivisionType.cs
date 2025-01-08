using System;
using System.Collections.Generic;

namespace ConsoleApp1__Seeding_DB_.Database;

public partial class DivisionType
{
    public int DivisionTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();

    public virtual ICollection<Street> Streets { get; set; } = new List<Street>();
}
