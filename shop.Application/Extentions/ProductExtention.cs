
using shop.Application.Dtos.Product;
using shop.Domain.Entities.Products;
using System;

namespace shop.Application.Extentions
{
    public static class ProductExtention
    {
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
