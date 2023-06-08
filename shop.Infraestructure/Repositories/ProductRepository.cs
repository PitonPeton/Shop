﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using shop.Domain.Entities.Products;
using shop.Infraestructure.Context;
using shop.Infraestructure.Core;
using shop.Infraestructure.Exceptions;
using shop.Infraestructure.Interfaces;
using shop.Infraestructure.Models;

namespace shop.Infraestructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private ILogger<ProductRepository> logger;
        private shopContext context;

        public ProductRepository(ILogger<ProductRepository> logger,
                                shopContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public override void Add(Product entity)
        {

            if (this.Exists(cd => cd.productname == entity.productname))
            {
                throw new ProductException("");
            }

            base.SaveChanges();
        }

        public List<ProductModel> GetProducts()
        {

            List<ProductModel> products = new List<ProductModel>();

            try
            {
                products = this.context.Products.Select(de => new ProductModel()
                {
                    productid = de.productid,
                    productname = de.productname,
                    unitprice = de.unitprice,
                    discontinued = de.discontinued
                }).ToList();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo productos", ex.ToString());
            }

            return products;
        }

    }
}
