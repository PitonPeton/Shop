namespace shop.Application.Dtos.Product
{
    public class ProductDeleteDto : DtoBase
    {
        public int productid { get; set; }
        public bool deleted { get; set; }
    }
}
