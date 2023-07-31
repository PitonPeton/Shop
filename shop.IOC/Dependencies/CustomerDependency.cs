using Microsoft.Extensions.DependencyInjection;
using shop.Infraestructure.Interfaces;
using shop.Infraestructure.Repositories;
using shop.Application.Contract;
using shop.Application.Service;

namespace shop.IOC.Dependencies
{
    public static class CustomerDependency
    {
        public static void AddCustomerDependecy(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();
        }
    }
}
