using Microsoft.EntityFrameworkCore;
using shop.Domain.Entities.Orders;
using shop.Domain.Entities.Shippers;

namespace shop.Infraestructure.Context
{
    public class shopContext : DbContext
    {
        public shopContext() { }

        public shopContext(DbContextOptions<shopContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Shipper> Shippers { get; set; }
    }
}
