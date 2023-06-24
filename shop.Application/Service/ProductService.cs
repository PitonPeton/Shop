
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;
using shop.Application.Contract;
using shop.Application.Core;
using shop.Application.Dtos.Product;
using shop.Domain.Entities.Products;
using shop.Infraestructure.Exceptions;
using shop.Infraestructure.Interfaces;
using System;
using shop.Infraestructure.Repositories;

namespace shop.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ILogger<ProductService> logger;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger) 
        {
            this.productRepository = productRepository;
            this.logger = logger;
        }
        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.productRepository.GetProducts();
            }
            catch (ProductException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{ result.Message }");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los productos";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.productRepository.GetProductId(id);
            }
            catch (ProductDataException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el producto";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Save(ProductAddDto model)
        {
            ServiceResult result = new ServiceResult();
            if (string.IsNullOrEmpty(model.productname))
            {
                result.Message = "El nombre del producto es requerido.";
                result.Success = false;
                return result;
            }
            if (model.productname.Length > 40)
            {
                result.Message = "El nombre del producto tiene una longitud invalida.";
                result.Success = false;
                return result;
            }
            if (!model.unitprice.HasValue)
            {
                result.Message = "El precio del producto es requerido.";
                result.Success = false;
                return result;
            }
            if (model.unitprice <= 0)
            {
                result.Message = "El precio del producto no puede ser 0";
                result.Success = false;
                return result;
            }
            if (!model.discontinued.HasValue)
            {
                result.Message = "Se requiere saber si el producto esta descontinuado.";
                result.Success = false;
                return result;
            }
            if (!model.supplierid.HasValue)
            {
                result.Message = "Se requiere la id del suplidor.";
                result.Success = false;
                return result;
            }
            if (!model.categoryid.HasValue)
            {
                result.Message = "Se requiere la id de la categoria del producto.";
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
                this.productRepository.Add(new Product()
                {
                    productname = model.productname,
                    unitprice = model.unitprice.Value,
                    categoryid = model.categoryid.Value,
                    supplierid = model.supplierid.Value,
                    creation_date = DateTime.Now,
                    creation_user = model.change_user.Value
                });
                result.Message = "Producto agregado correctamente.";
            }
            catch (ProductDataException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el producto.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult Update(ProductUpdateDto model)
        {
            ServiceResult result = new ServiceResult();
            
            if (string.IsNullOrEmpty(model.productname))
            {
                result.Message = "El nombre del producto es requerido.";
                result.Success = false;
                return result;
            }
            if (model.productname.Length > 40)
            {
                result.Message = "El nombre del producto tiene una longitud invalida.";
                result.Success = false;
                return result;
            }
            if (!model.unitprice.HasValue)
            {
                result.Message = "El precio del producto es requerido.";
                result.Success = false;
                return result;
            }
            if (model.unitprice <= 0)
            {
                result.Message = "El precio del producto no puede ser 0";
                result.Success = false;
                return result;
            }
            if (!model.discontinued.HasValue)
            {
                result.Message = "Se requiere saber si el producto esta descontinuado.";
                result.Success = false;
                return result;
            }
            if (!model.supplierid.HasValue)
            {
                result.Message = "Se requiere la id del suplidor.";
                result.Success = false;
                return result;
            }
            if (!model.categoryid.HasValue)
            {
                result.Message = "Se requiere la id de la categoria del producto.";
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
                this.productRepository.Update(new Product()
                {
                    productid = model.productid,
                    productname = model.productname,
                    unitprice = model.unitprice.Value,
                    discontinued = model.discontinued.Value,
                    categoryid = model.categoryid.Value,
                    supplierid = model.supplierid.Value,
                    modify_date = DateTime.Now,
                    modify_user = model.change_user.Value
                });
            }
            catch (ProductDataException dex)
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error modificando el producto.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult Delete(ProductDeleteDto model)
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
                this.productRepository.Delete(new Product()
                {
                    productid = model.productid,
                    deleted = model.deleted,
                    delete_date = DateTime.Now,
                    delete_user = model.change_user.Value,
                });

                result.Message = "Producto eliminado correctamente.";
            }
            catch (ProductDataException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el producto.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        
    }
}
