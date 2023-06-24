using System;

namespace shop.Infraestructure.Exceptions
{
    public class ProductException : Exception
    {
        public ProductException(string message) : base(message) 
        { 

        }
        
    }
    public class ProductDataException : Exception
    {
        public ProductDataException(string message) : base(message)
        {

        }

    }
}
