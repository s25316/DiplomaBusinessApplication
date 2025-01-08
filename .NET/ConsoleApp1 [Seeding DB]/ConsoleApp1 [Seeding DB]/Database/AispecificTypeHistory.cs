using System;
using System.Collections.Generic;

namespace ConsoleApp1__Seeding_DB_.Database;

public partial class AispecificTypeHistory
{
    public Guid InstitutionId { get; set; }

    public int TypeId { get; set; }

    public DateOnly Date { get; set; }

    public virtual AcademicInstitution Institution { get; set; } = null!;

    public virtual AispecificType Type { get; set; } = null!;
}
