﻿using System;
using System.Collections.Generic;
using System.Text;

namespace shop.Application.Dtos
{
    public abstract class DtoBase
    {
        public int modify_user { get; set; }
        public DateTime modify_date { get; set; }        
    }
}
