
namespace shop.Infraestructure.Models
{
    public class ProductModel
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public decimal unitprice { get; set; }
        public bool discontinued { get; set; }
    }
}
