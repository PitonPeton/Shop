using System;
using System.Collections.Generic;
using System.Data.Common;

namespace shop.Domain.Entities.Customer
{
    public partial class Customer : Core.Person
    {
        public int custid { get; set; }
        public string companyname { get; set; }
        public string contactname { get; set; }
        public string contacttitle { get; set; }
        public string email { get; set; }
        public string? fax { get; set; }

    }
}
