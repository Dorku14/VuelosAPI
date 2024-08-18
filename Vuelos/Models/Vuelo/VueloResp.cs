namespace Vuelos.Models.Vuelo
{
    public class VueloResp
    {
        public int VueloId { get; set; }
        public int AeropuertoDestinoId { get; set; }
        public string AeropuertoDestinoCodigo { get; set; }
        public int AeropuertoOrigenId { get; set; }
        public string AeropuertoOrigenCodigo { get; set; }
        public int AerolineaId { get; set; }
        public string AerolineaNombre { get; set; }
        public DateTime HoraSalida { get; set; }
        public string DuracionViaje { get; set; }
        public decimal Costo { get; set; }
    }
}
