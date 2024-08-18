using Vuelos.Models.Usuario;

namespace Vuelos.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioResp> ObtenerUsuario(UsuarioParams parametros, CancellationToken ct);
    }
}
