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
            InstytucjeSearchByEnum search = InstytucjeSearchByEnum.Nip,
            int maxItems = 100)
        {
            var result = await _service.GetInstytucjeAsync(
                value, search, maxItems, cancellation);

            return Ok(result);
        }

        [HttpGet("Branches")]
        public async Task<IActionResult> GetBranchesAsync(
            CancellationToken cancellation,
            string value,
            BranchesSearchByEnum search,
            int maxItems = 100)
        {
            var result = await _service.GetBranchesAsync(
                value, search, maxItems, cancellation);

            return Ok(result);
        }

        [HttpGet("Courses")]
        public async Task<IActionResult> GetBranchesAsync(
            CancellationToken cancellation,
            string value,
            CoursesSearchByEnum search,
            int maxItems = 100)
        {
            var result = await _service.GetCoursesAsync(
                value, search, maxItems, cancellation);

            return Ok(result);
        }

        [HttpGet("DoctoralSchools")]
        public async Task<IActionResult> GetDoctoralSchoolsAsync(
            CancellationToken cancellation,
            Guid doctoralSchoolGuid,
            int maxItems = 100)
        {
            var result = await _service.GetDoctoralSchoolsAsync(
                doctoralSchoolGuid, maxItems, cancellation);

            return Ok(result);
        }

        [HttpGet("SpecializedEducations")]
        public async Task<IActionResult> GetSpecializedEducationsAsync(
            CancellationToken cancellation,
            Guid institutionUuid,
            int maxItems = 100)
        {
            var result = await _service.GetSpecializedEducationsAsync(
                institutionUuid, maxItems, cancellation);

            return Ok(result);
        }
        //===============================================================================================
        //===============================================================================================
        //===============================================================================================
        //Private Methods
    }
}
