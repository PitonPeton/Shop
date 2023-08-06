using shop.Application.Dtos.Product;
using shop.Domain.Entities.Products;
using shop.Web.Models.Request;

namespace shop.Web.Models.Extention
{
    public static class ProductExtention
    {
        public static ProductAddDto ConvertSaveRequestToDto(this ProductSaveRequest productSave)
        {
            return new ProductAddDto()
            {

                productname = productSave.productname,
                unitprice = productSave.unitprice,
                categoryid = productSave.categoryid,
                supplierid = productSave.supplierid,

            };
        }
    }
}
