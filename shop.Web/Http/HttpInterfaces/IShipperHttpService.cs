using shop.Web.Http.Core;
using shop.Web.Models.Request;
using shop.Web.Models.Responses;

namespace shop.Web.Http.HttpInterfaces
{
    public interface IShipperHttpService : IBaseHttpService
                                            <ShipperListResponse,
                                             ShipperDetailResponse,
                                             ShipperAddRequest,
                                             ShipperUpdateRequest>
    {
    }
}
