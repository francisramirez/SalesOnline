﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SalesOnline.Console.Models
{
    public partial class Menu
    {
        public Menu()
        {
            InverseIdMenuPadreNavigation = new HashSet<Menu>();
            RolMenu = new HashSet<RolMenu>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? IdMenuPadre { get; set; }
        public string Icono { get; set; }
        public string Controlador { get; set; }
        public string PaginaAccion { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
        public int? IdUsuarioElimino { get; set; }
        public DateTime? FechaElimino { get; set; }
        public bool Eliminado { get; set; }

        public virtual Menu IdMenuPadreNavigation { get; set; }
        public virtual ICollection<Menu> InverseIdMenuPadreNavigation { get; set; }
        public virtual ICollection<RolMenu> RolMenu { get; set; }
    }
}