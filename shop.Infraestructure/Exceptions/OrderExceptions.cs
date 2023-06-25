using System;

namespace shop.Infraestructure.Exceptions
{
    public class OrderException : Exception
    {
        public OrderException(string message) : base(message)
        {

        }

    }

    public class OrderDataException : Exception
    {
        public OrderDataException(string message) : base(message)
        {

        }
    }
}
