using Microsoft.AspNetCore.Mvc;
using Regon.Repositories.Requests;
using Regon.ValueObjects;

namespace SimpleApp12__APIs__2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegonController : ControllerBase
    {
        private readonly RequestRepository _repository;

        public RegonController(RequestRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync(string key, CancellationToken cancellation)
        {
            var result = await _repository.ZalogujAsync((UserKey)key, cancellation, false);
            return Ok(result);
        }
    }
}
