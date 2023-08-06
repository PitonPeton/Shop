using shop.Web.Models.Reponses;

namespace shop.Web.Models.Responses
{
    public class CustomerListResponse : BaseReponse
    {
        public List<CustomerModel> data { get; set; }
    }
}
