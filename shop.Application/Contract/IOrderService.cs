using shop.Application.Core;
using shop.Application.Dtos.Order;

namespace shop.Application.Contract
{
    public interface IOrderService : IBaseService<OrderAddDto,
                                                    OrderUpdateDto,
                                                    OrderRemoveDto>
    { 
    }
}
