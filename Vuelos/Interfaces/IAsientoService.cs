using Vuelos.Models;
using Vuelos.Models.Asiento;

namespace Vuelos.Interfaces
{
    public interface IAsientoService
    {
        Task<List<AsientoResp>> ObtenerAsientos(int vueloId, CancellationToken ct);
        Task<ResponseBase> ApartarAsientos(List<AsientoDT> asientos, CancellationToken ct);
        Task<ResponseBase> ComprarAsientos(List<AsientoDT> asientos, CancellationToken ct);
    }
}
