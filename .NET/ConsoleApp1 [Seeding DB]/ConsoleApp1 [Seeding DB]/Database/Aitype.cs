using System;
using System.Collections.Generic;

namespace ConsoleApp1__Seeding_DB_.Database;

public partial class Aitype
{
    public int Id { get; set; }

    public bool IsSchool { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AcademicInstitution> AcademicInstitutions { get; set; } = new List<AcademicInstitution>();
}
