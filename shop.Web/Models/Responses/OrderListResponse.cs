using shop.Web.Models.Core;

namespace shop.Web.Models.Responses
{
    public class OrderListResponse : BaseResponseD
    {
        public List<OrderResponseModel>? data { get; set; }
    }
}
