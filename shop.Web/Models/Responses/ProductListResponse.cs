namespace shop.Web.Models.Responses
{
    public class ProductListResponse : ProductResponse
    {
        public List<ProductModel> data { get; set; }
    }
}
