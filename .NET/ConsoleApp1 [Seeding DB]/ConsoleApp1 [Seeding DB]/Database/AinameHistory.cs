using System;
using System.Collections.Generic;

namespace ConsoleApp1__Seeding_DB_.Database;

public partial class AinameHistory
{
    public Guid InstitutionId { get; set; }

    public DateOnly Date { get; set; }

    public string Name { get; set; } = null!;

    public virtual AcademicInstitution Institution { get; set; } = null!;
}
