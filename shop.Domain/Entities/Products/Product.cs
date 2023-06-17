using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace shop.Domain.Entities.Products
{

    [Table("Products", Schema = "Production")]
    public partial class Product : Core.BaseEntity
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public decimal unitprice { get; set; }
        public bool discontinued { get; set; }
        public int supplierid { get; set; }
        public int categoryid { get; set; }
    }
}
