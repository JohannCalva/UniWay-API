using System.ComponentModel.DataAnnotations;

namespace UniWay_API.Models.DTO.Vehiculo
{
    public class VehiculoCreateDTO
    {
        [Required]
        [MaxLength(50)]
        public string Marca { get; set; }
        [Required]
        [MaxLength(50)]
        public string Modelo { get; set; }
        [MaxLength(30)]
        public string Color { get; set; }
        [Required]
        [MaxLength(10)]
        public string Placa { get; set; }
        [Required]
        public int ConductorId { get; set; }
    }
}
