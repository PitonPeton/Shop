using System;
using shop.Domain.Core;

namespace shop.Domain.Entities.Orders
{
    public partial class Order : BaseEntity
    {
        public int Id { get; set; }
        public string? shipname { get; set; }
        public int? empid { get; set; }
        public int? custid { get; set; }
        public string? shipaddress { get; set; }
        public string? shipcity { get; set; }
        public string? shipregion { get; set; }
        public string? shippostalcode { get; set; }
        public DateTime shippeddate { get; set; }
        public int freight { get; set; }
        public string? shipcountry { get; set; }
        public DateTime requiredate { get; set; }
        public DateTime orderdate { get; set; }

    }
}