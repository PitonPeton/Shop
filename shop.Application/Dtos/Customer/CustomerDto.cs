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
        public string phone { get; set; }
        public string? city { get; set; }
        public string country { get; set; }
        public string? region { get; set; }
        public string address { get; set; }
        public string postalcode { get; set; }


    }
}
