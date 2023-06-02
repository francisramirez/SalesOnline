using Microsoft.EntityFrameworkCore;
using SalesOnline.Console.Models;
using System;
using System.Linq;

namespace SalesOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SalesContext context = new SalesContext();

            //var categoryProducts = context.Categoria.Include(cd => cd.ProductoCategoria)
            //                              .First(cd => cd.Id == 1);

            var productCategorys = context.Producto.Include(cd => cd.ProductoCategoria)
                                          .First(cd => cd.Id == 1003);


           // System.Console.Write("");
            
        }
    }
}
