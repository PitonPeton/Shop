using System;

namespace shop.Application.Dtos.Order
{
    public abstract class OrderDto : DtoBase
    {
        public decimal? freight { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime orderdate { get; set; }
        public int? creation_user { get; set; }
        public DateTime creation_date { get; set; }
    }
}
