using Vuelos.DataBase;
using Vuelos.Interfaces;
using Vuelos.Models.Usuario;
using Vuelos.Models.Vuelo;

namespace Vuelos.Services
{
    public class UsuarioService:IUsuarioService
    {
        private readonly AppDbContext _dbContext;

        public UsuarioService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UsuarioResp> ObtenerUsuario(UsuarioParams parametros, CancellationToken ct)
        {
            UsuarioResp resp = new UsuarioResp();
            try
            {
                var filtros = new Dictionary<string, object>();
                filtros.Add("UserName", parametros.Usuario);
                filtros.Add("Contrasenia", parametros.Contrasenia);
                var data = await _dbContext.ExecuteStoredProcedureAsync<UsuarioResp>("dbo.SelUsuario", filtros);
                if (data != null)
                {
                    resp = data.FirstOrDefault();
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return resp;
        }
    }
}
