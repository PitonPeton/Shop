using shop.Application.Dtos.Order;
using shop.Infraestructure.Models;
using shop.Web.Models.Responses;

namespace shop.Web.Services
{
    public interface IOrderApiService
    {
        OrderDetailResponse GetOrder(int id);
        OrderListResponse GetOrders();
        OrderUpdateResponse Update(OrderUpdateDto orderUpdateDto);
        OrderSaveResponse Save(OrderAddDto orderAddDto);

    }
}
