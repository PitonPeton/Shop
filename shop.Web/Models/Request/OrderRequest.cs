using shop.Web.Models.Core;

namespace shop.Web.Models.Request
{
    public class OrderRequest : BaseRequest
    {
        public int orderid { get; set; }
        public int? custid { get; set; }
        public int empid { get; set; }
        public int shipperid { get; set; }
        public decimal freight { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime orderdate { get; set; }
    }
}
