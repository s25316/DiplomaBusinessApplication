using Microsoft.AspNetCore.Mvc;
using RadonFlatFileDB.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadonFilesController : ControllerBase
    {
        private readonly IRadonService _service;

        public RadonFilesController(
            IRadonService service)
        {
            _service = service;
        }

        [HttpGet("Institutions")]
        public IActionResult GetInstitutions()
        {
            var result = _service.GetInstitutions();
            return Ok(result);
        }

        [HttpGet("Branches")]
        public IActionResult GetBranches()
        {
            var result = _service.GetBranches();
            return Ok(result);
        }

        [HttpGet("DoctoralSchools")]
        public IActionResult GetDoctoralSchools()
        {
            var result = _service.GetDoctoralSchools();
            return Ok(result);
        }

        [HttpGet("SpecialEducations")]
        public IActionResult GetSpecialEducations()
        {
            var result = _service.GetSpecialEducations();
            return Ok(result);
        }
    }
}
