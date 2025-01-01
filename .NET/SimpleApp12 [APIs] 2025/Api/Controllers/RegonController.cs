using Microsoft.AspNetCore.Mvc;
using Regon.Services.MainService;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegonController : ControllerBase
    {
        private readonly IRegonService _svc;
        private readonly string _key = "";

        public RegonController(IRegonService svc)
        {
            _svc = svc;
        }

        [HttpGet("DaneSzukaj")]
        public async Task<IActionResult> GetAsync(
            string value,
            string typeValue,
            CancellationToken cancellation)
        {
            var result = await _svc.DaneSzukajAsync(_key, value, typeValue, cancellation,
                true);
            return Ok(result);
        }

        [HttpGet("StatusUslugi")]
        public async Task<IActionResult> StatusUslugiAsync(CancellationToken cancellation,
            bool isProduction = true)
        {
            var result = await _svc.StatusUslugiAsync(cancellation, isProduction);
            return Ok(result);
        }


        [HttpGet("PelnyRaport")]
        public async Task<IActionResult> DanePobierzPelnyRaportAsync(
            CancellationToken cancellation,
            string value = "5262160983",
            string typeValue = "nip",
            bool isProduction = true)
        {
            var result = await _svc.DanePobierzPelnyRaportAsync(_key, value, typeValue, cancellation,
                true);
            return Ok(result);
        }

        [HttpGet("RaportPkd")]
        public async Task<IActionResult> RaportDzialalnosciPkdAsync(
            CancellationToken cancellation,
            string value = "5262160983",
            string typeValue = "nip",
            bool isProduction = true)
        {
            var result = await _svc.RaportDzialalnosciPkdAsync(_key, value, typeValue, cancellation,
                true);
            return Ok(result);
        }
    }
}
