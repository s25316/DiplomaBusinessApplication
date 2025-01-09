using Application.DatabaseRelational.Models.Companies.Classifications;
using Application.DatabaseRelational.Models.Companies.Identifiers;
using Application.DatabaseRelational.Models.Companies.Statuses;
using Application.DatabaseRelational.Models.HighSchools.Institutions;

namespace Application.DatabaseRelational.Models.Companies
{
    public class Company
    {
        //Properties
        public Guid Id { get; set; }
        //public ICollection<> Websites { get; set; } = new List<>();//Url
        //public ICollection<> Emails { get; set; } = new List<>();
        //public ICollection<> Phones { get; set; } = new List<>();

        //Dependencies
        public virtual ICollection<CompanyNameHistory> NamesHistory { get; set; } = new List<CompanyNameHistory>();
        public virtual ICollection<CompanyStatusHistory> StatusHistory { get; set; } = new List<CompanyStatusHistory>();
        public virtual ICollection<CompanyIdentifierDetail> Identifiers { get; set; } = new List<CompanyIdentifierDetail>();
        public virtual ICollection<CompanyClassificationDetail> Classifications { get; set; } = new List<CompanyClassificationDetail>();
        //Child
        public virtual AcademicInstitution? AcademicInstitution { get; set; } = null;
    }
}
