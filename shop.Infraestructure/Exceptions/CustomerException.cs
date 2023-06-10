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
        public class CustomerDataException : Exception
        {
            public CustomerDataException(string message) : base(message)
            {

            }

        }
    
}
