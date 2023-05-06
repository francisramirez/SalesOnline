namespace SalesOnline.Domain.Entities.Ventas
{
    public partial class TipoDocumentoVenta : Core.BaseEntity
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }

    }
}