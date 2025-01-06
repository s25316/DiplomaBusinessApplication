using RadonFlatFileDB.DTOs;

namespace RadonFlatFileDB.Repositories
{
    public interface IRadonRepository
    {
        IEnumerable<InstitutionDto> GetInstitutions(string? path = null);
        IEnumerable<BranchDto> GetBranches(string? path = null);
        IEnumerable<DoctoralSchoolDto> GetDoctoralSchools(string? path = null);
        IEnumerable<KsztalcenieSpecjalistyczneDto> GetSpecialEducations(string? path = null);
    }
}
