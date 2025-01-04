using Microsoft.AspNetCore.Mvc;
using Radon.Enums;
using Radon.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadonController : ControllerBase
    {
        //Properties
        private readonly IRadonService _service;


        //Constructor
        public RadonController(
            IRadonService service)
        {
            _service = service;
        }


        //===============================================================================================
        //===============================================================================================
        //===============================================================================================
        //Public Methods
        [HttpGet("Institution")]
        public async Task<IActionResult> GetInstitutionAsync(
            CancellationToken cancellation,
            string value = "5262160983",
            InstytucjeSearchByEnum search = InstytucjeSearchByEnum.Nip)
        {
            var result = await _service.GetInstytucjeAsync(
                value, search, cancellation);

            return Ok(result);
        }

        [HttpGet("Branches")]
        public async Task<IActionResult> GetBranchesAsync(
            CancellationToken cancellation,
            string value = "9d1eca9c-696f-4908-b65b-8c54eadeb76e",
            BranchesSearchByEnum search = (BranchesSearchByEnum)2)
        {
            var result = await _service.GetBranchesAsync(
                value, search, cancellation);

            return Ok(result);
        }

        [HttpGet("Courses")]
        public async Task<IActionResult> GetBranchesAsync(
            CancellationToken cancellation,
            string value = "9d1eca9c-696f-4908-b65b-8c54eadeb76e",
            CoursesSearchByEnum search = CoursesSearchByEnum.InstitutionUuid)
        {
            var result = await _service.GetCoursesAsync(
                value, search, cancellation);

            return Ok(result);
        }

        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_doctoral_school
        //6330acf8-576f-460a-ad48-d40709db6c8d
        [HttpGet("DoctoralSchools")]
        public async Task<IActionResult> GetDoctoralSchoolsAsync(
            CancellationToken cancellation,
            Guid doctoralSchoolGuid)
        {
            var result = await _service.GetDoctoralSchoolsAsync(
                doctoralSchoolGuid, cancellation);

            return Ok(result);
        }

        //https://radon.nauka.gov.pl/api/katalog-udostepniania-danych/dane-polon/polon/reports_specialized_education
        //830f0560-3a72-4201-8db5-201dfd9bbfa4
        [HttpGet("SpecializedEducations")]
        public async Task<IActionResult> GetSpecializedEducationsAsync(
            CancellationToken cancellation,
            Guid institutionUuid)
        {
            var result = await _service.GetSpecializedEducationsAsync(
                institutionUuid, cancellation);

            return Ok(result);
        }
        //===============================================================================================
        //===============================================================================================
        //===============================================================================================
        //Private Methods
    }
}
