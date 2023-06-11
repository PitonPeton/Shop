using System;

namespace shop.Infraestructure.Exceptions
{
    public class OrderException : Exception
    {
        public OrderException(string message) : base(message)
        {

        }

    }
}
