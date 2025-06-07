namespace UniWay_API.Models.DTO.Reserva
{
    public class ReservaCreateDTO
    {
        public Estado Estado { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public int ViajeId { get; set; }
        public int PasajeroId { get; set; }
    }
}
