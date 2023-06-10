﻿using System;
using System.Collections.Generic;
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

        public override void Add(Customer entity)
        {


            if (this.Exists(cd => cd.companyname == entity.companyname))
            {
                throw new CustomerException("");
            }


            if (this.Exists(cd => cd.contactname == entity.contactname))
            {
                throw new CustomerException("El cliente ya existe");
            }

            base.Add(entity);

            base.SaveChanges();
        }

        public List<CustomerModel> GetCustomer()
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
                    email = de.email,
                    fax = de.fax
                }).ToList();
            }
            catch (Exception ex)
            {


                this.logger.LogError("Error obteniendo cliente", ex.ToString());

                this.logger.LogError("Error obteniendo al cliente", ex.ToString());

            }

            return customers;
        }
        public CustomerModel GetCustomerId(int id)
        {
            CustomerModel customerModel = new CustomerModel();

            try
            {
                Customer customer = this.GetEntity(id);

                customerModel.custid = customer.custid;
                customerModel.companyname = customer.companyname;
                customerModel.contactname = customer.contactname;
                customerModel.contacttitle = customer.contacttitle;
                customerModel.email = customer.email;
                customerModel.fax = customer.fax;
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo al cliente", ex.ToString());
            }
            return customerModel;
        }

        public override void Update(Customer entity)
        {
            try
            {
                Customer customerToUpdate = this.GetEntity(entity.custid);
                customerToUpdate.custid = entity.custid;
                customerToUpdate.companyname = entity.companyname;
                customerToUpdate.contactname = entity.contactname;
                customerToUpdate.contacttitle = entity.contacttitle;
                customerToUpdate.modify_date = entity.modify_date;
                customerToUpdate.modify_user = entity.modify_user;

                this.context.Customers.Update(customerToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizando al cliente", ex.ToString());
            }
        }

        public override void Delete(Customer entity)
        {
            try
            {
                Customer customerToDelete = this.GetEntity(entity.custid);
                customerToDelete.deleted = entity.deleted;
                customerToDelete.delete_date = DateTime.Now;
                customerToDelete.delete_user = entity.delete_user;

                this.context.Customers.Update(customerToDelete);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error eliminando al cliente", ex.ToString());
            }
            base.SaveChanges();
        }

    }
}
