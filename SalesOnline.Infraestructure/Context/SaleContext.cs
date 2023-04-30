using Microsoft.EntityFrameworkCore;
using SalesOnline.Domain.Entities;

namespace SalesOnline.Infraestructure.Context
{
    public partial class SaleContext : DbContext
    {
        public SaleContext()
        {

        }
        public SaleContext(DbContextOptions<SaleContext> options) :base(options)
        {

        }
       
    }
}
