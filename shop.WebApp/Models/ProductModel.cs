﻿namespace shop.WebApp.Models
{
    public class ProductModel
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public decimal unitprice { get; set; }
        public bool discontinued { get; set; }
        public int supplierid { get; set; }
        public int categoryid { get; set; }
    }
}
