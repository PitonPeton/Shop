using System;
using System.Collections.Generic;
using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace shop.Domain.Entities.Customer
{
    [Table("Customers", Schema = "Sales")]
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
