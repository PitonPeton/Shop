﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Extensions.Logging;
using shop.Domain.Entities.Customer;
using shop.Infraestructure.Context;
using shop.Infraestructure.Core;
using shop.Infraestructure.Exceptions;
using shop.Infraestructure.Interfaces;
using shop.Infraestructure.Models;

namespace shop.Infraestructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private ILogger<CustomerRepository> logger;
        private shopContext context;

        public CustomerRepository(ILogger<CustomerRepository> logger,
                                shopContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public List<CustomerModel> GetCustomers()
        {

            List<CustomerModel> customers = new List<CustomerModel>();

            try
            {
                customers = this.context.Customers.Select(de => new CustomerModel()
                {
                    custid = de.custid,
                    companyname = de.companyname,
                    contactname = de.contactname,
                    contacttitle = de.contacttitle,
                    address = de.address,
                    email = de.email,
                    city = de.city,
                    region = de.region,
                    postalcode = de.postalcode,
                    country = de.country,
                    phone = de.phone,
                    fax = de.fax

                }).ToList();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo los clientes", ex.ToString());
            }

            return customers;
        }

        public CustomerModel GetCustomerId(int id)
        {
            CustomerModel customerModel = new CustomerModel();

            try
            {
                Customer customer = this.GetEntity(id);

                if (customer == null) 
                {
                    throw new CustomerDataException("El cliente no existe.");
                }

                customerModel.custid = customer.custid;
                customerModel.companyname = customer.companyname;
                customerModel.contactname = customer.contactname;
                customerModel.contacttitle = customer.contacttitle;
                customerModel.address = customer.address;
                customerModel.email = customer.email;
                customerModel.city = customer.city;
                customerModel.region = customer.region;
                customerModel.postalcode = customer.postalcode;
                customerModel.country = customer.country;
                customerModel.phone = customer.phone;
                customerModel.fax = customer.fax;

            }
            catch (CustomerDataException dex)
            {
                throw new CustomerDataException(dex.Message);
            }
            catch (Exception ex)
            {
                string error = "Error obteniendo al cliente";
                this.logger.LogError(error, ex.ToString());
            }
            return customerModel;
        }
        public override void Add(Customer entity)
        {

            if (this.Exists(cd => cd.companyname == entity.companyname))
            {
                throw new CustomerException("El cliente existe");
            }

            base.Add(entity);
            base.SaveChanges();
        }
        public override void Update(Customer entity)
        {
            try
            {
                Customer customerToUpdate = this.GetEntity(entity.custid);

                if (customerToUpdate == null)
                {
                    throw new CustomerDataException("El cliente no existe.");
                }

                customerToUpdate.custid = entity.custid;
                customerToUpdate.companyname = entity.companyname;
                customerToUpdate.contactname = entity.contactname;
                customerToUpdate.contacttitle = entity.contacttitle;
                customerToUpdate.address = entity.address;
                customerToUpdate.email = entity.email;
                customerToUpdate.city = entity.city;
                customerToUpdate.region = entity.region;
                customerToUpdate.postalcode = entity.postalcode;
                customerToUpdate.country = entity.country;
                customerToUpdate.phone = entity.phone;
                customerToUpdate.fax = entity.fax;
                customerToUpdate.modify_date = entity.modify_date;
                customerToUpdate.modify_user = entity.modify_user;

                this.context.Customers.Update(customerToUpdate);
                this.context.SaveChanges();
            }
            catch (CustomerDataException dex)
            {
                throw new CustomerDataException(dex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizando el cliente", ex.ToString());
            }
        }
        public override void Delete(Customer entity)
        {
            try
            {
                Customer customerToDelete = this.GetEntity(entity.custid);

                if (customerToDelete == null)
                {
                    throw new CustomerDataException("El cliente no existe.");
                }

                customerToDelete.deleted = entity.deleted;
                customerToDelete.delete_date = DateTime.Now;
                customerToDelete.delete_user = entity.delete_user;

                this.context.Customers.Update(customerToDelete);
                this.context.SaveChanges();
            }
            catch (CustomerDataException dex)
            {
                throw new CustomerDataException(dex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error eliminando cliente", ex.ToString());
            }
            base.SaveChanges();
        }
    }
}
