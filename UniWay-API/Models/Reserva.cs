using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniWay_API.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Estado Estado { get; set; }
        [Required]
        public MetodoPago MetodoPago { get; set; }
        [Required]
        public int ViajeId { get; set; }
        [ForeignKey("ViajeId")]
        public Viaje? Viaje { get; set; }
        [Required]
        public int PasajeroId { get; set; }
        [ForeignKey("PasajeroId")]
        public Usuario? Pasajero { get; set; } 
    }
    public enum Estado
    {
        Pendiente,
        Confirmada,
        Cancelada
    }
    public enum MetodoPago
    {
        Efectivo,
        Transferencia
    }
}
