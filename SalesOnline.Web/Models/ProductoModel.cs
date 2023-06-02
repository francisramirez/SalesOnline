namespace SalesOnline.Web.Models
{
    public class ProductoModel
    {
        public int productoId { get; set; }
        public string? marca { get; set; }
        public string? descripcion { get; set; }
        public string? categoria { get; set; }
        public int stock { get; set; }
        public decimal precio { get; set; }

        public string codigoBarra { get; set; }
        public int idCategoria { get; set; }
        public string urlImagen { get; set; }
        public string nombreImagen { get; set; }
    }
}
