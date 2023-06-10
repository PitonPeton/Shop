using System;
using System.Collections.Generic;
using System.Text;

namespace shop.Infraestructure.Exceptions
{
    public class CustomerException : Exception
    {
        public CustomerException(string message) : base(message) 
        { 

        }
        
    }
}
