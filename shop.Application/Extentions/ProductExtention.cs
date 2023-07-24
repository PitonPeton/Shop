
using shop.Application.Core;
using shop.Application.Dtos.Product;
using shop.Domain.Entities.Products;
using System;

namespace shop.Application.Extentions
{
    public static class ProductExtention
    {
        //dejare las validaciones aqui, a fin de que funcione al menos.
        public static ServiceResult ValidUser(this ProductDeleteDto model)
        {
            ServiceResult result = new ServiceResult();

            if (!model.change_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
                return result;
            }

            return result;
        }
        public static ServiceResult IsValidProduct(this ProductDto model)
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

            return result;
        }
        public static Product ConvertDtoAddToEntity(this ProductAddDto productAddDto)
        {
            return new Product()
            {
                productname = productAddDto.productname,
                unitprice = productAddDto.unitprice.Value,
                categoryid = productAddDto.categoryid.Value,
                supplierid = productAddDto.supplierid.Value,
                creation_date = DateTime.Now,
                creation_user = productAddDto.change_user.Value
            };
        }
        public static Product ConvertDtoUpdateToEntity(this ProductUpdateDto productUpdateDto)
        {
            return new Product()
            {
                productid = productUpdateDto.productid,
                productname = productUpdateDto.productname,
                unitprice = productUpdateDto.unitprice.Value,
                discontinued = productUpdateDto.discontinued.Value,
                categoryid = productUpdateDto.categoryid.Value,
                supplierid = productUpdateDto.supplierid.Value,
                modify_date = DateTime.Now,
                modify_user = productUpdateDto.change_user.Value
            };
        }
    }
}
