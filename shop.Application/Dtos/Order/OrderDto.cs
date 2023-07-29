using System;

namespace shop.Application.Dtos.Order
{
    public abstract class OrderDto : DtoBase
    {
        public int? custid { get; set; }
        public int? empid { get; set; }
        public int? shipperid { get; set; }
        public decimal? freight { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime orderdate { get; set; }
    }
}
