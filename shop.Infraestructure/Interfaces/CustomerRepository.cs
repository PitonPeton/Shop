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
        List<CustomerModel> GetCustomer();
        CustomerModel GetCustomerId(int id);
    }
}