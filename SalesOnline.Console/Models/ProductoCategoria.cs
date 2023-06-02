namespace SalesOnline.Console.Models
{
    public partial class ProductoCategoria
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Producto Producto { get; set; }
    }
}