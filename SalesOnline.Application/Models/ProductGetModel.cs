using System.ComponentModel;

namespace SalesOnline.Application.Models
{
    public class ProductGetModel
    {
        public int ProductoId { get; set; }
        public string? Marca { get; set; }
        public string? Descripcion { get; set; }
        public string? Categoria { get; set; }
        public int? Stock { get; set; }
        public decimal? Precio { get; set; }

    }
}
