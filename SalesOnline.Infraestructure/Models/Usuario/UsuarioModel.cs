
namespace SalesOnline.Infraestructure.Models.Usuario
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public int? IdRol { get; set; }
        public string? UrlFoto { get; set; }
        public string? NombreFoto { get; set; }
    }
}
