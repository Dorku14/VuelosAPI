using System.Threading.Tasks;
using Vuelos.Models.Vuelo;

namespace Vuelos.Interfaces
{
    public interface IVueloService
    {
        Task<List<VueloResp>> ObtenerVuelos(VueloParams parametros, CancellationToken ct);
    }
}
