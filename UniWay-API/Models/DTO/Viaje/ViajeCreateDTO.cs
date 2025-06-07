using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UniWay_API.Models.DTO.Viaje
{
    public class ViajeCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Origen { get; set; }
        [Required]
        [MaxLength(100)]
        public string Destino { get; set; }
        [Required]
        public DateTime FechaHoraSalida { get; set; }
        [Required]
        [Precision(10, 2)]
        public decimal Precio { get; set; }
        [Required]
        public int AsientosDisponibles { get; set; }
        [Required]
        public int ConductorId { get; set; }
    }
}
