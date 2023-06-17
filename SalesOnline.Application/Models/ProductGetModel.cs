

namespace SalesOnline.Application.Models
{
    public class ProductGetModel
    {
        public int ProductoId { get; set; }
        public string? CodigoBarra { get; set; }
        public string? Marca { get; set; }
        public string? Descripcion { get; set; }
         public int? Stock { get; set; }
        public string? UrlImagen { get; set; }
        public string? NombreImagen { get; set; }
        public decimal? Precio { get; set; }



    }
}
