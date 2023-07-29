using System;
using System.Collections.Generic;
using System.Text;

namespace shop.Application.Dtos.Shipper
{
    public class ShipperRemoveDto : DtoBase
    {
        public int shipperid { get; set; }
        public bool Deleted { get; set; }
    }
}
