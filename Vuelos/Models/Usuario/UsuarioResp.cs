namespace Vuelos.Models.Usuario
{
    public class UsuarioResp
    {
        public int UsuarioId { get; set; }
        public int TipoUsuarioId { get; set; }
        public string TipoUsuarioNombre { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string UserName { get; set; }
        public string Correo {  get; set; }
    }
}
