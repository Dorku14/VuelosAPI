using Microsoft.EntityFrameworkCore;
using Vuelos.DataBase;
using Vuelos.Interfaces;
using Vuelos.Models.Vuelo;

namespace Vuelos.Services
{
    public class VueloService:IVueloService
    {
        private readonly AppDbContext _dbContext;

        public VueloService(AppDbContext dbContext)
        {
           _dbContext = dbContext;
        }
        public async Task<List<VueloResp>> ObtenerVuelos(VueloParams parametros, CancellationToken ct)
        {
            List<VueloResp>  resp = new List<VueloResp>();
            try
            {
                var filtros = new Dictionary<string, object>();
                filtros.Add("Fecha", parametros.Fecha);
                filtros.Add("AerolineaId", parametros.AerolienaId);
                filtros.Add("AeropuertoDestinoId", parametros.AeropuertoDestinoId);
                var data = await _dbContext.ExecuteStoredProcedureAsync<VueloResp>("dbo.SelVuelos", filtros);
                if (data != null) {
                    resp = data;
                }
               
            }
            catch (Exception ex) {
                string msg = ex.Message;
            }
            return resp;
        }
    }

}
