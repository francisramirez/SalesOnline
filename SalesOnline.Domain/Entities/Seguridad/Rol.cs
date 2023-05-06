using System;

namespace SalesOnline.Domain.Entities.Seguridad
{
    public partial class Rol : Core.BaseEntity
    {

        public int Id { get; set; }
        public string? Descripcion { get; set; }

    }
}