using System;
using System.Collections.Generic;
using System.Text;
using shop.Domain.Core;

namespace shop.Domain.Core
{
    public class Articles : BaseEntity
    {
        public int orderid { get; set; }
        public DateTime orderdate { get; set; }
        public DateTime requiredate { get; set; }
    }
}
