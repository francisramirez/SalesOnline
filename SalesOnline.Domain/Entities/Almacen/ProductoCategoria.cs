
namespace SalesOnline.Domain.Entities.Almacen
{
    public partial class ProductoCategoria
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public Producto? Producto { get; set; }

    }
}
