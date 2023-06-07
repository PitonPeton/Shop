using Microsoft.EntityFrameworkCore;
using shop.Domain.Entities;
using shop.Domain.Entities.Products;

namespace shop.Infraestructure.Context
{
    public class shopContext : DbContext
    {
        public shopContext() { }

        public shopContext(DbContextOptions<shopContext> options) : base(options)
        { 
        }
        public DbSet<Product> Products { get; set; }
    }
}
