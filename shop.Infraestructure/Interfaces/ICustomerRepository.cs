using shop.Domain.Entities.Customer;
using shop.Domain.Repository;
using shop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace shop.Infraestructure.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
<<<<<<< HEAD:shop.Infraestructure/Interfaces/CustomerRepository.cs
        List<CustomerModel> GetCustomer();
=======
        List<CustomerModel> GetCustomers();
>>>>>>> Actualizacion:shop.Infraestructure/Interfaces/ICustomerRepository.cs
        CustomerModel GetCustomerId(int id);
    }
}