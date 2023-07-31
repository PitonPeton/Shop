
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;
using shop.Application.Contract;
using shop.Application.Core;
using shop.Application.Dtos.Customer;
using shop.Domain.Entities.Customer;
using shop.Infraestructure.Exceptions;
using shop.Infraestructure.Interfaces;
using System;
using shop.Infraestructure.Repositories;
using shop.Application.Extentions;

namespace shop.Application.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ILogger<CustomerService> logger;
        public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger) 
        {
            this.customerRepository = customerRepository;
            this.logger = logger;
        }
        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.customerRepository.GetCustomers();
            }
            catch (CustomerException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{ result.Message }");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los clientes";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.customerRepository.GetCustomerId(id);
            }
            catch (CustomerDataException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el customer";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Save(CustomerAddDto model)
        {
            ServiceResult result = new ServiceResult();

            result = model.IsValidCustomer();

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var customer = model.ConvertDtoAddToEntity();

                this.customerRepository.Add(customer);
                
                result.Message = "Cliente agregado correctamente.";
            }
            catch (CustomerDataException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el cliente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult Update(CustomerUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            result = model.IsValidCustomer();

            if (!result.Success) 
            { 
                return result; 
            }

            try
            {
                var customer = model.ConvertDtoUpdateToEntity();

                this.customerRepository.Update(customer);

                result.Message = "El cliente se ha modificado satisfactoriamente.";
            }
            catch (CustomerDataException dex)
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error modificando al cliente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult Delete(CustomerDeleteDto model)
        {
            ServiceResult result = new ServiceResult();

            result = model.ValidUser();

            if (!result.Success)
            {
                return result;
            }

            try
            {
                this.customerRepository.Delete(new Customer()
                {
                    custid = model.custid,
                    deleted = model.deleted,
                    delete_date = DateTime.Now,
                    delete_user = model.change_user.Value,
                });

                result.Message = "El cliente eliminado correctamente.";
            }
            catch (CustomerDataException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando al cliente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        
    }
}
