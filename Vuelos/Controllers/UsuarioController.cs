using Microsoft.AspNetCore.Mvc;
using Vuelos.Interfaces;
using Vuelos.Models.Usuario;
using Vuelos.Models.Vuelo;

namespace Vuelos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _us;
        public UsuarioController(IUsuarioService us)
        {
            _us = us;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioResp))]
        [HttpGet()]
        public async Task<IActionResult> IniciarSesion([FromQuery] UsuarioParams up,CancellationToken ct)
        {
            var data = await _us.ObtenerUsuario(up, ct);
            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return Conflict("Usuario o contraseña incorrecta");
            }
        }
    }
}
