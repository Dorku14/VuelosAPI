using Microsoft.AspNetCore.Mvc;
using Vuelos.Interfaces;
using Vuelos.Models.Asiento;
using Vuelos.Models.Vuelo;

namespace Vuelos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsientoController : Controller
    {
        private readonly IAsientoService _asientoS;
        public AsientoController(IAsientoService asientoS)
        {
            _asientoS = asientoS;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<VueloResp>))]
        [HttpGet()]
        public async Task<IActionResult> ObtenerVuelos([FromQuery] int VueloId, CancellationToken ct)
        {
            var data = await _asientoS.ObtenerAsientos(VueloId, ct);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return Conflict("Ocurrió un error");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<VueloResp>))]
        [HttpPost("apartar")]
        public async Task<IActionResult> ApartarAsientos([FromBody] List<AsientoDT> asientos, CancellationToken ct)
        {
            var data = await _asientoS.ApartarAsientos(asientos, ct);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return Conflict("Ocurrió un error");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<VueloResp>))]
        [HttpPost("comprar")]
        public async Task<IActionResult> ComprarAsientos([FromBody] List<AsientoDT> asientos, CancellationToken ct)
        {
            var data = await _asientoS.ComprarAsientos(asientos, ct);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return Conflict("Ocurrió un error");
            }
        }
    }
}
