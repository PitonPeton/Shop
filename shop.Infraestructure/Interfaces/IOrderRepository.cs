using shop.Domain.Entities.Orders;
using shop.Domain.Repository;
using shop.Infraestructure.Models;
using System.Collections.Generic;


namespace shop.Infraestructure.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>  
    {
        List<OrderModel> GetOrders();
        OrderModel GetOrderById(int orderid);
    }
}
