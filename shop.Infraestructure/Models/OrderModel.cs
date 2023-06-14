using System;

namespace shop.Infraestructure.Models
{
    public class OrderModel
    {
        public int orderid { get; set; }
        public int freight { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime orderdate { get; set; }
    }
}
