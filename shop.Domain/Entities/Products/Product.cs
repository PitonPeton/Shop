using System;
using System.Collections.Generic;
using System.Data.Common;

namespace shop.Domain.Entities.Products
{
    public partial class Product : Core.BaseEntity
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public decimal unitprice { get; set; }
        public bool discontinued { get; set; }
    }
}
