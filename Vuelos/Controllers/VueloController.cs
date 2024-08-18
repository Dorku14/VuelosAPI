using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Vuelos.Interfaces;
using Vuelos.Models.Vuelo;

namespace Vuelos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VueloController : ControllerBase
    {
        private readonly IVueloService _vs;
        public VueloController(IVueloService vs) {
            _vs = vs;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<VueloResp>))]
        [HttpGet()]
        public async Task<IActionResult> ObtenerVuelos([FromQuery] VueloParams vp,CancellationToken ct)
        {
            var data = await _vs.ObtenerVuelos(vp,ct);
            if (data != null)
            {
                return Ok(data);
            }
            else {
                return Conflict("Ocurrió un error");
            }
        }
    }
}
