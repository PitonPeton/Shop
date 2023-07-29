using System;
using System.Collections.Generic;
using System.Text;

namespace shop.Application.Dtos
{
    public abstract class DtoBase
    {
        public int? Change_user { get; set; }
        public DateTime Change_date { get; set; }        
    }
}
