<<<<<<< HEAD
<<<<<<< HEAD:shop.Infraestructure/Models/CustomerModel.cs
=======
>>>>>>> Actualizacion
﻿
namespace shop.Infraestructure.Models
{
    public class CustomerModel
<<<<<<< HEAD
=======
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace shop.Application.Dtos.Customer
{
    public abstract class CustomerDto : DtoBase
>>>>>>> Actualizacion:shop.Application/Dtos/Customer/CustomerDto.cs
    {
=======
    {
        public int custid { get; set; }
>>>>>>> Actualizacion
        public string companyname { get; set; }
        public string contactname { get; set; }
        public string contacttitle { get; set; }
        public string email { get; set; }
        public string? fax { get; set; }
    }
}
