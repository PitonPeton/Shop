using shop.Web.Models.Core;

namespace shop.Web.Models.Responses 
{
    public class ShipperListResponse : BaseResponseD
    {
        public List<ShipperResponseModel>? data { get; set; }
    }
}