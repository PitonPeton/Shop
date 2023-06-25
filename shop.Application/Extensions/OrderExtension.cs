using shop.Application.Dtos.Order;
using shop.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace shop.Application.Extensions
{
    public static class OrderExtention
    {
        public static Order ConvertDtoAddToEntity(this OrderDto order) 
        {
            return new Order() 
            {
            };
        }
    }
}
