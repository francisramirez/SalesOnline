using SalesOnline.Domain.Core;

namespace SalesOnline.Domain.Entities
{
    public class Suplidor : BaseEntity
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Contacto { get; set; }
        public string? Direccion { get; set; }
        public string? Ciudad { get; set; }
        public string? Region { get; set; }
        public string? CodigoPostal { get; set; }
        public string? Telefono { get; set; }
        public string? Fax { get; set; }
        
    }
}
