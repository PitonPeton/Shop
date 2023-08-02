namespace shop.Web.Models.Responses
{
    public class ProductListResponse : BaseResponse
    {
        public List<ProductModel> data { get; set; }
    }
}
