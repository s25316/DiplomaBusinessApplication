using Radon.DTOs.ApiResponses.Branches;
using Radon.DTOs.ApiResponses.Courses;
using Radon.DTOs.ApiResponses.DoctoralSchools;
using Radon.DTOs.ApiResponses.Institutions;
using Radon.DTOs.ApiResponses.SpecializedEducations;
using Radon.DTOs.ApiResponses.Template;
using Radon.Enums;
using Radon.Repositories;
using System.Text.Json;

namespace Radon.Services
{
    public class RadonService : IRadonService
    {
        //Properties
        private readonly IRadonRepository _repository;


        //Constructor
        public RadonService(IRadonRepository repository)
        {
            _repository = repository;
        }


        //===============================================================================================
        //===============================================================================================
        //===============================================================================================
        //Public Methods
        public async Task<Institution?> GetInstytucjeAsync(
            string value,
            InstytucjeSearchByEnum search,
            int maxItems = 100,
            CancellationToken cancellation = default)
        {
            var json = await _repository.GetInstytucjeAsync(value, search, maxItems, null, cancellation);
            var x = Deserialize<Institution>(json);
            return x.Items.FirstOrDefault();
        }

        public async Task<IEnumerable<BranchDto>> GetBranchesAsync(
            string value,
            BranchesSearchByEnum search,
            int maxItems = 100,
            CancellationToken cancellation = default)
        {
            var json = await _repository.GetBranchesAsync(value, search, maxItems, null, cancellation);
            var x = Deserialize<BranchDto>(json);
            return x.Items;
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesAsync(
            string value,
            CoursesSearchByEnum search,
            int maxItems = 100,
            CancellationToken cancellation = default)
        {
            var json = await _repository.GetCoursesAsync(value, search, maxItems, null, cancellation);
            var x = Deserialize<CourseDto>(json);
            return x.Items;
        }

        public async Task<IEnumerable<DoctoralSchoolDto>> GetDoctoralSchoolsAsync(
            Guid doctoralSchoolGuid,
            int maxItems = 100,
            CancellationToken cancellation = default)
        {
            var json = await _repository.GetDoctoralSchoolsAsync(
                doctoralSchoolGuid, maxItems, null, cancellation);
            var x = Deserialize<DoctoralSchoolDto>(json);
            return x.Items;
        }

        public async Task<IEnumerable<SpecializedEducationDto>> GetSpecializedEducationsAsync(
            Guid institutionUuid,
            int maxItems = 100,
            CancellationToken cancellation = default)
        {
            var json = await _repository.GetSpecializedEducationsAsync(
                institutionUuid, maxItems, null, cancellation);
            var x = Deserialize<SpecializedEducationDto>(json);
            return x.Items;
        }
        //===============================================================================================
        //===============================================================================================
        //===============================================================================================
        //Private Methods
        private (IEnumerable<T> Items, string? Token, int Count) Deserialize<T>(
            string json) where T : class
        {
            var response = JsonSerializer.Deserialize<ApiResponse<T>>(json);
            var items = response?.Results ?? [];
            var token = response?.Pagination.Token;
            var count = response?.Pagination.MaxCount ?? 0;
            return (items, token, count);
        }
    }
}
