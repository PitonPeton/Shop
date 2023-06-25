using System;

namespace shop.Infraestructure.Models
{
    public class OrderModel
    {
        public decimal freight { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime orderdate { get; set; }
    }
}
