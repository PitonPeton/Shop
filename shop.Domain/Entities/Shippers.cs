using System;
using System.Collections.Generic;
using shop.Domain.Core;

namespace shop.Domain.Entities.Shippers
{
    public partial class Shipper : BaseEntity
    {
        public int shipperid { get; set; }
        public string? companyname { get; set; }
        public string? phone { get; set; }
        public string? shipname { get; set; }
        public string? shipaddress { get; set; }
        public string? shipcity { get; set; }
        public string? shipregion { get; set; }
        public string? shippostalcode { get; set; }
        public DateTime shippeddate { get; set; }
        public string? shipcountry { get; set; }
    }
}

