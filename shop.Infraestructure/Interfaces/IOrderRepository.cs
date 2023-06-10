using shop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace shop.Infraestructure.Interfaces
{
    public class IOrderRepository   
    {
        Task<List<OrderModel>> GetOrdersByOrderid(int orderid);
        Task<OrderOrderidModel> GetOrderid(int productoId);
    }
}
