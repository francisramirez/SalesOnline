namespace SalesOnline.Domain.Entities.Configuracion
{
    public partial class Configuracion
    {
        public short Id { get; set; }
        public string? Recurso { get; set; }
        public string? Propiedad { get; set; }
        public string? Valor { get; set; }
    }
}