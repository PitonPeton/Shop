using shop.Web.Services.Core;
using shop.Web.Models.Request;
using shop.Web.Models.Responses;

namespace shop.Web.Services
{
    public interface IOrderApiService : IApiService
                                            <OrderListResponse,
                                            OrderDetailResponse,
                                            OrderAddRequest,
                                            OrderUpdateRequest>
    { 
    }
}
