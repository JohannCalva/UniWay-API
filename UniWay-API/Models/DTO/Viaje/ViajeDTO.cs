namespace UniWay_API.Models.DTO.Viaje
{
    public class ViajeReadDTO
    {
        public int Id { get; set; }

        public string Origen { get; set; }

        public string Destino { get; set; }

        public DateTime FechaHoraSalida { get; set; }

        public decimal Precio { get; set; }

        public int AsientosDisponibles { get; set; }

        public int ConductorId { get; set; }
    }
}
