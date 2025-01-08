using System;
using System.Collections.Generic;

namespace ConsoleApp1__Seeding_DB_.Database;

public partial class AcademicInstitution
{
    public Guid Id { get; set; }

    public Guid? ParentId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly CreationDate { get; set; }

    public DateOnly? LiquidationStartDate { get; set; }

    public DateOnly? LiquidationDate { get; set; }

    public string? Www { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int TypeId { get; set; }

    public DateOnly LastUpdate { get; set; }

    public virtual ICollection<AinameHistory> AinameHistories { get; set; } = new List<AinameHistory>();

    public virtual ICollection<AispecificTypeHistory> AispecificTypeHistories { get; set; } = new List<AispecificTypeHistory>();

    public virtual ICollection<AistatusHistory> AistatusHistories { get; set; } = new List<AistatusHistory>();

    public virtual ICollection<AcademicInstitution> InverseParent { get; set; } = new List<AcademicInstitution>();

    public virtual AcademicInstitution? Parent { get; set; }

    public virtual Aitype Type { get; set; } = null!;
}
