
namespace shop.Application.Dtos.Order
{
    public class OrderRemoveDto : DtoBase
    {
        public int orderid { get; set; }
        public bool deleted { get; set; }
    }
}
