using shop.Application.Dtos.Product;
using shop.Web.Models.Request;
using shop.Web.Models.Responses;

namespace shop.Web.Services
{
    public interface IProductApiService
    {
        ProductDetailResponse GetProduct(int id);
        ProductListResponse GetProducts();

        ProductUpdateRequest Update(ProductUpdateDto productUpdateDto);
        ProductSaveRequest Save(ProductAddDto productAddDto);
    }
}
