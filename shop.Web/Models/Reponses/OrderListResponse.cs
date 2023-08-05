namespace shop.Web.Models.Responses
{
    public class OrderListResponse : BaseResponse
    {
        public List<OrderModel> data { get; set; }
    }
}
