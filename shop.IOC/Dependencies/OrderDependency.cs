using Microsoft.Extensions.DependencyInjection;
using shop.Application.Contract;
using shop.Application.Service;
using shop.Infraestructure.Interfaces;
using shop.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace shop.IOC.Dependencies
{
    public static class OrderDependency
    {
        public static void AddOrderDependecy(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderService, OrderService>();
        }
    }
}
