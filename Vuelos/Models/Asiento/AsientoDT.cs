namespace Vuelos.Models.Asiento
{
    public class AsientoDT
    {
        public int VueloAsientoId { get; set; }
        public int VueloId {  get; set; }
        public int UsuarioId { get; set; }
        public int AsientoId { get; set; }
        public bool EsReservado { get; set; }
        public bool EsAparatado { get; set; }
        public decimal Total { get; set; }
        public DateTime? FechaApartado { get; set; }
    }
}
