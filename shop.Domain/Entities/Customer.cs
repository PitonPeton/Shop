
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace shop.Domain.Entities.Customer
{
    [Table("Customers", Schema = "Sales")]
    public partial class Customer : Core.Person
    {
        [Key]
        public int custid { get; set; }
        public string companyname { get; set; }
        public string contactname { get; set; }
        public string contacttitle { get; set; }
        public string email { get; set; }
        public string? fax { get; set; }

    }
}
