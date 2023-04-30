using SalesOnline.Domain.Core;

namespace SalesOnline.Domain.Entities
{
    public class Categoria : BaseEntity
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
       
    }
}
