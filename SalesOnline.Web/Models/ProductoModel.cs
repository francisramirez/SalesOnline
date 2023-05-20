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
    }
}
