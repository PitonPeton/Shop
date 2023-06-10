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
            }

            return customers;
        }

    }
}
