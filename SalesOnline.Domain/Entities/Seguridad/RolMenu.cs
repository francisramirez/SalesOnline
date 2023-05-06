using System;

namespace SalesOnline.Domain.Entities.Seguridad
{
    public partial class RolMenu : Core.BaseEntity
    {
        public int Id { get; set; }
        public int? IdRol { get; set; }
        public int? IdMenu { get; set; }


    }
}