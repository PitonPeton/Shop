using System;
using System.ComponentModel.DataAnnotations.Schema;
using shop.Domain.Core;

namespace shop.Domain.Entities.Orders
{
    [Table("Orders", Schema = "Sales")]
    public partial class Order : BaseEntity
    {
        public int orderid { get; set; }
        public int freight { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime orderdate { get; set; }

    }
}