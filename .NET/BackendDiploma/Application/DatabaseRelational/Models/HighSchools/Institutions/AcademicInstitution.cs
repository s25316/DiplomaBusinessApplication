namespace Application.DatabaseRelational.Models.HighSchools.Institutions
{
    public class AcademicInstitution
    {
        //Properties
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; } = null;
        public string Name { get; set; } = null!;
        public DateOnly CreationDate { get; set; }
        public DateOnly? LiquidationStartDate { get; set; } = null;
        public DateOnly? liquidationDate { get; set; } = null;
        public string? WWW { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Phone { get; set; } = null;
        public int TypeId { get; set; }
        public DateOnly LastUpdate { get; set; }

        //Dependencies
        public AIType Type { get; set; } = null!;
        public virtual ICollection<AISpecificTypeHistory> SpecificTypeHistories { get; set; } = new List<AISpecificTypeHistory>();
        public virtual ICollection<AIStatusHistory> StatusHistories { get; set; } = new List<AIStatusHistory>();
        public virtual ICollection<AINameHistory> NameHistories { get; set; } = new List<AINameHistory>();

        public virtual AcademicInstitution? ParentInstitution { get; set; } = null;
        public virtual ICollection<AcademicInstitution> ChildInstitutions { get; set; } = new List<AcademicInstitution>();
    }
}
