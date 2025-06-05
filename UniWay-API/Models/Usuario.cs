using System.ComponentModel.DataAnnotations;

namespace UniWay_API.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string IdBanner { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Correo { get; set; }
        [Required]
        [Phone]
        [MaxLength(15), MinLength(10)]
        public string Telefono { get; set; }
        [Required]
        [MaxLength(100)]
        public string Contrasena { get; set; }
        [Required]
        public bool EsConductor { get; set; }

    }
}
