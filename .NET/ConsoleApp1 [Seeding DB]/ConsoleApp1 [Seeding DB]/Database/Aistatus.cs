using System;
using System.Collections.Generic;

namespace ConsoleApp1__Seeding_DB_.Database;

public partial class Aistatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AistatusHistory> AistatusHistories { get; set; } = new List<AistatusHistory>();
}
