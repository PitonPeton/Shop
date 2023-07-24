using Microsoft.Extensions.DependencyInjection;
using shop.Infraestructure.Interfaces;
using shop.Infraestructure.Repositories;
using shop.Application.Contract;
using shop.Application.Service;

namespace shop.IOC.Dependencies
{
    public static class ProductDependency
    {
        public static void AddProductDependecy(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
