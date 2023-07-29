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
    public static class ShipperDependency
    {
        public static void AddShipperDependecy(this IServiceCollection services)
        {
            services.AddScoped<IShipperRepository, ShipperRepository>();
            services.AddTransient<IShipperService, ShipperService>();
        }
    }
}
