namespace Vuelos.Models.Asiento
{
    public class AsientoResp
    {
        public int AsientoId {  get; set; }
        public int VueloAsientoId {  get; set; }
        public int VueloId { get; set; }
        public bool EsReservado { get; set; }
        public bool EsApartado { get; set; }
    }
}
