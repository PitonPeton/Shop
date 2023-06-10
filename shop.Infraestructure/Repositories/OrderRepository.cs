using shop.Domain.Entities.Orders;
using shop.Infraestructure.Core;
using shop.Infraestructure.Interfaces;
using System.Collections.Generic;

namespace shop.Infraestructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public List<Order> GetOrdersByOrder(int orderId)
        {
            throw new System.NotImplementedException();
        }
    }
}
