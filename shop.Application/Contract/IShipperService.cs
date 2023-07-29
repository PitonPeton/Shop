using shop.Application.Core;
using shop.Application.Dtos.Shipper;

namespace shop.Application.Contract
{
    public interface IShipperService : IBaseService<ShipperAddDto,
                                                    ShipperUpdateDto,
                                                    ShipperRemoveDto>
    {
    }
}
