﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                    discontinued = de.discontinued,
                    categoryid = de.categoryid,
                    supplierid = de.supplierid

            }).ToList();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo productos", ex.ToString());
            }

            return products;
        }

        public ProductModel GetProductId(int id)
        {
            ProductModel productModel = new ProductModel();

            try
            {
                Product product = this.GetEntity(id);

                if (product == null) 
                {
                    throw new ProductDataException("El producto no existe.");
                }

                productModel.productid = product.productid;
                productModel.productname = product.productname;
                productModel.unitprice = product.unitprice;
                productModel.discontinued = product.discontinued;
                productModel.categoryid = product.categoryid;
                productModel.supplierid = product.supplierid;
            }
            catch (ProductDataException dex)
            {
                throw new ProductDataException(dex.Message);
            }
            catch (Exception ex)
            {
                string error = "Error obteniendo producto";
                this.logger.LogError(error, ex.ToString());
            }
            return productModel;
        }
        public override void Add(Product entity)
        {

            if (this.Exists(cd => cd.productname == entity.productname))
            {
                throw new ProductException("Producto Existe");
            }

            base.Add(entity);
            base.SaveChanges();
        }
        public override void Update(Product entity)
        {
            try
            {
                Product productToUpdate = this.GetEntity(entity.productid);

                if (productToUpdate == null)
                {
                    throw new ProductDataException("El producto no existe.");
                }

                productToUpdate.productid = entity.productid;
                productToUpdate.productname = entity.productname;
                productToUpdate.unitprice = entity.unitprice;
                productToUpdate.discontinued = entity.discontinued;
                productToUpdate.categoryid = entity.categoryid;
                productToUpdate.supplierid = entity.supplierid;
                productToUpdate.modify_date = entity.modify_date;
                productToUpdate.modify_user = entity.modify_user;

                this.context.Products.Update(productToUpdate);
                this.context.SaveChanges();
            }
            catch (ProductDataException dex)
            {
                throw new ProductDataException(dex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizando producto", ex.ToString());
            }
        }
        public override void Delete(Product entity)
        {
            try
            {
                Product productToDelete = this.GetEntity(entity.productid);

                if (productToDelete == null)
                {
                    throw new ProductDataException("El producto no existe.");
                }

                productToDelete.deleted = entity.deleted;
                productToDelete.delete_date = entity.delete_date;
                productToDelete.delete_user = entity.delete_user;

                this.context.Products.Update(productToDelete);
                this.context.SaveChanges();
            }
            catch (ProductDataException dex)
            {
                throw new ProductDataException(dex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error eliminando producto", ex.ToString());
            }
            base.SaveChanges();
        }
    }
}
