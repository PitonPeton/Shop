using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using shop.Domain.Core;

namespace shop.Domain.Entities.Orders
{
    [Table("Orders", Schema = "Sales")]
    public partial class Order : BaseEntity
    {
        [Key]
        public int orderid { get; set; }

        [ForeignKey("Customer")]
        public int? custid { get; set; }

        [ForeignKey("Employee")]
        public int empid { get; set; }

        [ForeignKey("Shipper")]
        public int shipperid { get; set; }
        public decimal freight { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime orderdate { get; set; }

    }

    [Table("Customers", Schema = "Sales")]
    public class Customer
    {
        [Key]
        public int custid { get; set; }
        public string companyName { get; set; }
        public string contactName { get; set; }
        public string contactTitle { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
    }


[Table("Employees", Schema = "HR")]
    public class Employee    {
        [Key] 
        public int empid { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string title { get; set; }
        public string titleofcourtesy { get; set; }
        public DateTime birthdate { get; set; }
        public DateTime hiredate { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postalcode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public int? mgrid { get; set; }
    }
}