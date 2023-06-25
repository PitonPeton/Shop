using System;

namespace shop.Infraestructure.Exceptions
{
    public class ShipperException : Exception
    {
        public ShipperException(string message) : base(message)
        {

        }

    }

    public class ShipperDataException : Exception
    {
        public ShipperDataException(string message) : base(message)
        {

        }
    }
}
