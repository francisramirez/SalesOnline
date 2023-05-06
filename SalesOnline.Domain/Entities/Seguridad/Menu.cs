namespace SalesOnline.Domain.Entities.Seguridad
{
    public partial class Menu : Core.BaseEntity
    {

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public int? IdMenuPadre { get; set; }
        public string? Icono { get; set; }
        public string? Controlador { get; set; }
        public string? PaginaAccion { get; set; }


    }
}