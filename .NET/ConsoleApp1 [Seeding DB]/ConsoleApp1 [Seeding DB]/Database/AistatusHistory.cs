using System;
using System.Collections.Generic;

namespace ConsoleApp1__Seeding_DB_.Database;

public partial class AistatusHistory
{
    public Guid InstitutionId { get; set; }

    public int StatusId { get; set; }

    public DateOnly Date { get; set; }

    public virtual AcademicInstitution Institution { get; set; } = null!;

    public virtual Aistatus Status { get; set; } = null!;
}
