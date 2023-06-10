using System;
using System.Collections.Generic;
using System.Text;

namespace shop.Application.Dtos.Customer
{
    public abstract class CustomerDto : DtoBase
    {
        public string companyname { get; set; }
        public string contactname { get; set; }
        public string contacttitle { get; set; }
        public string email { get; set; }
        public string? fax { get; set; }
    }
}
