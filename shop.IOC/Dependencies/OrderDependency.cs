using Microsoft.Extensions.DependencyInjection;
using shop.Application.Contract;
using shop.Application.Service;
using shop.Infraestructure.Interfaces;
using shop.Infraestructure.Repositories;

namespace shop.IOC.Dependencies
{
    public static class OrderDependency
    {
        public static void AddOrderDependency(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();
        }
    }
}
