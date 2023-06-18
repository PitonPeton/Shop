using System;
using System.Collections.Generic;
using System.Text;

namespace shop.Application.Dtos
{
    public abstract class DtoBase
    {
        public int change_user { get; set; }
        public DateTime change_date { get; set; }        
    }
}
