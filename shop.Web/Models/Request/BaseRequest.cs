using shop.Web.Models.Responses;

namespace shop.Web.Models.Request
{
    public class BaseRequest : BaseResponse
    {
        public DateTime change_date { get; set; }
        public int? change_user { get; set; }
    }
}
