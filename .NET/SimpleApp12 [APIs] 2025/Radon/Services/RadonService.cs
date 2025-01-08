using Radon.DTOs.ApiResponses.Branches;
using Radon.DTOs.ApiResponses.Courses;
using Radon.DTOs.ApiResponses.Disciplines;
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
        private readonly int _maxItems = 100;


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
            CancellationToken cancellation = default)
        {
            var json = await _repository.GetInstytucjeAsync(value, search, _maxItems, null, cancellation);
            var x = Deserialize<Institution>(json);
            return x.Items.FirstOrDefault();
        }

        public async Task<IEnumerable<BranchDto>> GetBranchesAsync(
            string value,
            BranchesSearchByEnum search,
            CancellationToken cancellation = default)
        {
            var items = new List<BranchDto>();
            var totalCount = -1;
            string? token = null;
            do
            {
                var json = await _repository.GetBranchesAsync(value, search, _maxItems, token, cancellation);
                var x = Deserialize<BranchDto>(json);

                token = x.Token;
                items.AddRange(x.Items);
                if (totalCount < 0)
                {
                    totalCount = x.Count;
                }
            }
            while (totalCount != items.Count);
            return items;
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesAsync(
            string value,
            CoursesSearchByEnum search,
            CancellationToken cancellation = default)
        {
            var items = new List<CourseDto>();
            var totalCount = -1;
            string? token = null;
            do
            {
                var json = await _repository.GetCoursesAsync(value, search, _maxItems, token, cancellation);
                var x = Deserialize<CourseDto>(json);

                token = x.Token;
                items.AddRange(x.Items);
                if (totalCount < 0)
                {
                    totalCount = x.Count;
                }
            }
            while (totalCount != items.Count);
            return items;
        }

        public async Task<DoctoralSchoolDto?> GetDoctoralSchoolsAsync(
            Guid doctoralSchoolGuid,
            CancellationToken cancellation = default)
        {
            var json = await _repository.GetDoctoralSchoolsAsync(
                doctoralSchoolGuid, _maxItems, null, cancellation);
            var x = Deserialize<DoctoralSchoolDto>(json);
            return x.Items.FirstOrDefault();
        }

        public async Task<IEnumerable<SpecializedEducationDto>> GetSpecializedEducationsAsync(
            Guid institutionUuid,
            CancellationToken cancellation = default)
        {
            var items = new List<SpecializedEducationDto>();
            var totalCount = -1;
            string? token = null;
            do
            {
                var json = await _repository.GetSpecializedEducationsAsync(
                    institutionUuid, _maxItems, token, cancellation);
                var x = Deserialize<SpecializedEducationDto>(json);

                token = x.Token;
                items.AddRange(x.Items);
                if (totalCount < 0)
                {
                    totalCount = x.Count;
                }
            }
            while (totalCount != items.Count);
            return items;
        }

        public async Task<IEnumerable<Discipline>> GetDisciplinesAsync(
            CancellationToken cancellation = default)
        {
            var json = await _repository.GetDisciplinesAsync(cancellation);
            return DeserializeList<Discipline>(json);
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

        private IEnumerable<T> DeserializeList<T>(
            string json) where T : class
        {
            var items = JsonSerializer.Deserialize<List<T>>(json);
            return items ?? [];
        }
    }
}
