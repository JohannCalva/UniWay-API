namespace UniWay_API.Models.DTO.Usuario
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string IdBanner { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool EsConductor { get; set; }
    }
}
