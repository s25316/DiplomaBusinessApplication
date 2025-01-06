using RadonFlatFileDB.DTOs;
using RadonFlatFileDB.Features.Branches.Entities;
using RadonFlatFileDB.Features.DoctoralSchools;
using RadonFlatFileDB.Features.Institutions.Entities;

namespace RadonFlatFileDB.Services
{
    public interface IRadonService
    {
        IEnumerable<Institution> GetInstitutions(string? path = null);
        IEnumerable<Branch> GetBranches(string? path = null);
        IEnumerable<DoctoralSchoolPair> GetDoctoralSchools(string? path = null);
        IEnumerable<KsztalcenieSpecjalistyczneDto> GetSpecialEducations(string? path = null);
    }
}
