
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
using shop.Application.Extentions;

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

            result = model.IsValidProduct();

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var product = model.ConvertDtoAddToEntity();

                this.productRepository.Add(product);
                
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

            result = model.IsValidProduct();

            if (!result.Success) 
            { 
                return result; 
            }

            try
            {
                var product = model.ConvertDtoUpdateToEntity();

                this.productRepository.Update(product);

                result.Message = "El producto se ha modificado correctamente.";
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

            result = model.ValidUser();

            if (!result.Success)
            {
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
