using System;
using System.Collections.Generic;
using System.Text;

namespace shop.Infraestructure.Models
{
    public class OrderShipperModel
    {
        public OrderShipperModel(OrderModel orderModel)
        {
            this.OrderModel = new OrderModel();
            OrderModel = orderModel;
        }

        public OrderModel OrderModel { get; }
    }
}
