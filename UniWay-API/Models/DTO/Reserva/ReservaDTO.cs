namespace UniWay_API.Models.DTO.Reserva
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public Estado Estado { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public int ViajeId { get; set; }
        public int PasajeroId { get; set; }
    }
}
