
using Vuelos.DataBase;
using Vuelos.Interfaces;
using Vuelos.Models;
using Vuelos.Models.Asiento;
using Vuelos.Models.Usuario;

namespace Vuelos.Services
{
    public class AsientoService:IAsientoService
    {
        private readonly AppDbContext _dbContext;

        public AsientoService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<AsientoResp>> ObtenerAsientos(int vueloId, CancellationToken ct)
        {
            List<AsientoResp> resp = new List<AsientoResp>();
            try
            {
                var filtros = new Dictionary<string, object>();
                filtros.Add("VueloId", vueloId);
                var data = await _dbContext.ExecuteStoredProcedureAsync<AsientoResp>("dbo.SelAsientos", filtros);
                if (data != null)
                {
                    resp = data;
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return resp;
        }

        public async Task<ResponseBase> ApartarAsientos(List<AsientoDT> asientos, CancellationToken ct)
        {
            ResponseBase resp=new ResponseBase();
            try
            {
                foreach (var item in asientos) {
                    var filtros = new Dictionary<string, object>();
                    filtros.Add("VueloAsientoId", item.VueloAsientoId);
                    filtros.Add("VueloId", item.VueloId);
                    filtros.Add("UsuarioId", item.UsuarioId);
                    filtros.Add("AsientoId", item.AsientoId);
                    filtros.Add("EsReservado", item.EsReservado);
                    filtros.Add("EsApartado", item.EsAparatado);
                    filtros.Add("FechaApartado", item.FechaApartado);
                    var data = await _dbContext.ExecuteStoredProcedureAsync<AsientoResp>("dbo.InsUpdAsientoVuelo", filtros);
                }
                resp.Mensaje = "Exitoso";
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return resp;
        }

        public async Task<ResponseBase> ComprarAsientos(List<AsientoDT> asientos, CancellationToken ct)
        {
            ResponseBase resp = new ResponseBase();
            try
            {
                foreach (var item in asientos)
                {
                    var filtros = new Dictionary<string, object>();
                    filtros.Add("VueloAsientoId", item.VueloAsientoId);
                    filtros.Add("VueloId", item.VueloId);
                    filtros.Add("UsuarioId", item.UsuarioId);
                    filtros.Add("AsientoId", item.AsientoId);
                    filtros.Add("EsReservado", item.EsReservado);
                    filtros.Add("EsApartado", item.EsAparatado);
                    filtros.Add("FechaApartado", item.FechaApartado);
                    var data = await _dbContext.ExecuteStoredProcedureAsync<AsientoResp>("dbo.InsUpdAsientoVuelo", filtros);
                }
                var asiento = asientos.FirstOrDefault();
                string numConfirmacion = Guid.NewGuid().ToString();
                if (asiento != null )
                {
                    var filros2 = new Dictionary<string, object>();
                    filros2.Add("UsuarioId", asiento.UsuarioId);
                    filros2.Add("VueloId", asiento.VueloId);
                    filros2.Add("NumeroConfirmacion", numConfirmacion);
                    filros2.Add("Total", asiento.Total);
                    await _dbContext.ExecuteStoredProcedureAsync<AsientoResp>("dbo.InsUsuarioVuelo", filros2);
                }
              
                resp.Mensaje = numConfirmacion;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return resp;
        }
    }
}
