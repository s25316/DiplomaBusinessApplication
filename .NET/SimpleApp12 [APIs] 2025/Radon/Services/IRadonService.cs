using Radon.DTOs.ApiResponses.Branches;
using Radon.DTOs.ApiResponses.Courses;
using Radon.DTOs.ApiResponses.DoctoralSchools;
using Radon.DTOs.ApiResponses.Institutions;
using Radon.DTOs.ApiResponses.SpecializedEducations;
using Radon.Enums;

namespace Radon.Services
{
    public interface IRadonService
    {
        Task<Institution?> GetInstytucjeAsync(
            string value,
            InstytucjeSearchByEnum search,
            CancellationToken cancellation = default);
        Task<IEnumerable<BranchDto>> GetBranchesAsync(
            string value,
            BranchesSearchByEnum search,
            CancellationToken cancellation = default);
        Task<IEnumerable<CourseDto>> GetCoursesAsync(
            string value,
            CoursesSearchByEnum search,
            CancellationToken cancellation = default);
        Task<DoctoralSchoolDto?> GetDoctoralSchoolsAsync(
            Guid doctoralSchoolGuid,
            CancellationToken cancellation = default);
        Task<IEnumerable<SpecializedEducationDto>> GetSpecializedEducationsAsync(
            Guid institutionUuid,
            CancellationToken cancellation = default);
    }
}
