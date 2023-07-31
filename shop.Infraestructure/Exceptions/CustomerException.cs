using System;

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