using System.Collections.Generic;

namespace shop.Infraestructure.Models
{
    public class OrderShipperModel
    {
        public OrderShipperModel(OrderModel orderModel)
        {
            this.OrderModel = new OrderModel();
            this.ShipperModels = new List<ShipperModel>();
        }

        public OrderModel? OrderModel { get; set; }
        public List<ShipperModel> ShipperModels { get; set; }
    }
}
