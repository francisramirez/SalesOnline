namespace SalesOnline.Web.Models.Requests
{
    public class CreateUserRequest
    {
        public int idUsuario { get; set; }
        public DateTime fecha { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public int idRol { get; set; }
        public string urlFoto { get; set; }
        public string nombreFoto { get; set; }
        public string clave { get; set; }
    }
}
