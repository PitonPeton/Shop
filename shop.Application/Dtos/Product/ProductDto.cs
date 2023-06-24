﻿namespace shop.Application.Dtos.Product
{
    public abstract class ProductDto : DtoBase
    {
        public string? productname { get; set; }
        public decimal? unitprice { get; set; }
        public bool? discontinued { get; set; }
        public int? supplierid { get; set; }
        public int? categoryid { get; set; }
    }
}
