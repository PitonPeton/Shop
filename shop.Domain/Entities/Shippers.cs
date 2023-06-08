using System.Collections.Generic;
using shop.Domain.Core;

namespace shop.Domain.Entities.Shippers
{
    public partial class Shipper : BaseEntity
    {
        public int shipperid { get; set; }
        public string? companyname { get; set; }
        public string? phone { get; set; }
    }
}

