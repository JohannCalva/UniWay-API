namespace UniWay_API.Models.DTO.Vehiculo
{
    public class VehiculoDTO
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Placa { get; set; }
        public int ConductorId { get; set; }
    }
}
