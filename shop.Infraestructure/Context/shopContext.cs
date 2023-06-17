using Microsoft.EntityFrameworkCore;
using shop.Domain.Entities;
using shop.Domain.Entities.Customer;
using System;

namespace shop.Infraestructure.Context
{
    public class shopContext : DbContext
    {
        public shopContext() { }

        public shopContext(DbContextOptions<shopContext> options) : base(options)
        { 
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
