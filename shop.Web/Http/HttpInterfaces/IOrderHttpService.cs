using shop.Web.Http.Core;
using shop.Web.Models.Responses;
using shop.Web.Models.Request;

namespace shop.Web.Http.HttpInterfaces
{
    public interface IOrderHttpService : IBaseHttpService
                                            <OrderListResponse,
                                             OrderDetailResponse,
                                             OrderAddRequest,
                                             OrderUpdateRequest>
    {
    }
}
