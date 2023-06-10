
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
                result.Data = this.customerRepository.GetCustomer();
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
                result.Message = "Error obteniendo a los clientes";
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
                result.Message = "Error obteniendo al cliente";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Save(CustomerAddDto model)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(model.contactname))
            {
                result.Message = "El nombre del cliente es necesario.";
                result.Success = false;
                return result;
            }
            if (model.contactname.Length > 40)
            {
                result.Message = "El nombre del cliente tiene una longitud invalida.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.companyname))
            {
                result.Message = "El nombre de la compañia es necesario.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.contacttitle))
            {
                result.Message = "El titulo del contacto es necesario.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.address))
            {
                result.Message = "La direccion del cliente es necesaria.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.email))
            {
                result.Message = "El email del cliente es necesario.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.city))
            {
                result.Message = "La ciudad del cliente es necesaria.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.country))
            {
                result.Message = "El pais del cliente es necesario.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.phone))
            {
                result.Message = "El telefono del cliente es necesario.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.fax))
            {
                result.Message = "El fax del cliente es necesario.";
                result.Success = false;
                return result;
            }
            if (!model.change_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
                return result;
            }
            try
            {
                var customer = model.ConvertDtoAddToEntity();

                this.customerRepository.Add(customer);
                
                result.Message = "El cliente agregado correctamente.";
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
                result.Message = "Error guardando al cliente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult Update(CustomerUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(model.contactname))
            {
                result.Message = "El nombre del cliente es necesario.";
                result.Success = false;
                return result;
            }
            if (model.contactname.Length > 40)
            {
                result.Message = "El nombre del cliente tiene una longitud invalida.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.companyname))
            {
                result.Message = "El nombre de la compañia es necesario.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.contacttitle))
            {
                result.Message = "El titulo del contacto es necesario.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.address))
            {
                result.Message = "La direccion del cliente es necesaria.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.email))
            {
                result.Message = "El email del cliente es necesario.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.city))
            {
                result.Message = "La ciudad del cliente es necesaria.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.country))
            {
                result.Message = "El pais del cliente es necesario.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.phone))
            {
                result.Message = "El telefono del cliente es necesario.";
                result.Success = false;
                return result;
            }
            if (string.IsNullOrEmpty(model.fax))
            {
                result.Message = "El fax del cliente es necesario.";
                result.Success = false;
                return result;
            }
            if (!model.change_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
                return result;
            }
            try
            {
                var customer = model.ConvertDtoUpdateToEntity();

                this.customerRepository.Update(customer);

                result.Message = "El cliente se ha modificado exitosamente.";
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
            
            if (!model.change_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
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

                result.Message = "Cliente eliminado satisfactoriamente.";
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
                result.Message = "Error eliminando el cliente.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        
    }
}
