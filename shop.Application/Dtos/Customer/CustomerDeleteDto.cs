
namespace shop.Application.Dtos.Customer
{
    public class CustomerDeleteDto : DtoBase
    {
        public int custid { get; set; }
        public bool deleted { get; set; }
    }
}
