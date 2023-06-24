
using shop.Application.Core;
using shop.Application.Dtos.Product;

namespace shop.Application.Contract
{
    public interface IProductService : IBaseService<ProductAddDto,
                                                    ProductUpdateDto,
                                                    ProductDeleteDto>
    {
    }
}
