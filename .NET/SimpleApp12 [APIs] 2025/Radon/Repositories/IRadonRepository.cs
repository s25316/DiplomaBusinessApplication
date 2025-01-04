using Radon.Enums;

namespace Radon.Repositories
{
    public interface IRadonRepository
    {
        Task<string> GetInstytucjeAsync(
            string value,
            InstytucjeSearchByEnum search,
            int maxItems = 100,
            string? token = null,
            CancellationToken cancellation = default);
        Task<string> GetBranchesAsync(
            string value,
            BranchesSearchByEnum search,
            int maxItems = 100,
            string? token = null,
            CancellationToken cancellation = default);
        Task<string> GetCoursesAsync(
            string value,
            CoursesSearchByEnum search,
            int maxItems = 100,
            string? token = null,
            CancellationToken cancellation = default);
        Task<string> GetDoctoralSchoolsAsync(
            Guid doctoralSchoolGuid,
            int maxItems = 100,
            string? token = null,
            CancellationToken cancellation = default);
        Task<string> GetSpecializedEducationsAsync(
            Guid institutionUuid,
            int maxItems = 100,
            string? token = null,
            CancellationToken cancellation = default);
    }
}
