using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniWay_API.Models
{
    public class Viaje
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Origen { get; set; }
        [Required]
        [MaxLength(100)]
        public string Destino { get; set; }
        [Required]
        public DateTime FechaHoraSalida { get; set; }
        [Range(0.01, 999.99)]
        public decimal Precio { get; set; }
        [Required]
        public int AsientosDisponibles { get; set; }
        [Required]
        public int ConductorId { get; set; }
        [ForeignKey("ConductorId")]
        public Usuario? Conductor { get; set; }
    }
}
