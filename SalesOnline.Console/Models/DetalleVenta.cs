﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SalesOnline.Console.Models
{
    public partial class DetalleVenta
    {
        public int Id { get; set; }
        public int? IdVenta { get; set; }
        public int? IdProducto { get; set; }
        public string MarcaProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string CategoriaProducto { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }

        public virtual Venta IdVentaNavigation { get; set; }
    }
}