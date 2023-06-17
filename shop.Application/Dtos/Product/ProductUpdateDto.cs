namespace shop.Application.Dtos.Product
{
    public class ProductUpdateDto : ProductDto
    {
        public int productid { get; set; }
        public bool discontinued { get; set; }
    }
}
