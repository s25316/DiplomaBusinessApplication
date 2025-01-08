using System;
using System.Collections.Generic;

namespace ConsoleApp1__Seeding_DB_.Database;

public partial class AispecificType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AispecificTypeHistory> AispecificTypeHistories { get; set; } = new List<AispecificTypeHistory>();
}
