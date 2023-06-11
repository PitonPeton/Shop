using System;
using shop.Domain.Core;

namespace shop.Domain.Entities.Orders
{
    public partial class Order : BaseEntity
    {
        public int orderid { get; set; }
        public int? empid { get; set; }
        public int? custid { get; set; }
        public int freight { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime orderdate { get; set; }

    }
}