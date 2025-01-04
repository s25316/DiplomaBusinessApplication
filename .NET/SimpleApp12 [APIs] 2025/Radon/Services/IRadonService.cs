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
            int maxItems = 100,
            CancellationToken cancellation = default);
        Task<IEnumerable<BranchDto>> GetBranchesAsync(
            string value,
            BranchesSearchByEnum search,
            int maxItems = 100,
            CancellationToken cancellation = default);
        Task<IEnumerable<CourseDto>> GetCoursesAsync(
            string value,
            CoursesSearchByEnum search,
            int maxItems = 100,
            CancellationToken cancellation = default);
        Task<IEnumerable<DoctoralSchoolDto>> GetDoctoralSchoolsAsync(
            Guid doctoralSchoolGuid,
            int maxItems = 100,
            CancellationToken cancellation = default);
        Task<IEnumerable<SpecializedEducationDto>> GetSpecializedEducationsAsync(
            Guid institutionUuid,
            int maxItems = 100,
            CancellationToken cancellation = default);
    }
}
