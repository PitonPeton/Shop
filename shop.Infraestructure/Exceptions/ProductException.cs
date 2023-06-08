using System;
using System.Collections.Generic;
using System.Text;

namespace shop.Infraestructure.Exceptions
{
    public class ProductException : Exception
    {
        public ProductException(string message) : base(message) 
        { 

        }
        
    }
}
