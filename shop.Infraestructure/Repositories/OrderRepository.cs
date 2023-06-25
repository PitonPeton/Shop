using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using shop.Domain.Entities.Orders;
using shop.Infraestructure.Context;
using shop.Infraestructure.Core;
using shop.Infraestructure.Exceptions;
using shop.Infraestructure.Interfaces;
using shop.Infraestructure.Models;

namespace shop.Infraestructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {

        private ILogger<OrderRepository> logger;
        private shopContext context;

        public OrderRepository(ILogger<OrderRepository> logger,
                                shopContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }

        public List<OrderModel> GetOrders()
        {
            List<OrderModel> orders = new List<OrderModel>();

            try
            {
                orders = this.context.Orders.Select(de => new OrderModel()
                {
                    orderdate = de.orderdate,
                    requireddate = de.requireddate,
                    freight = de.freight
                }).ToList();
            }
            catch(Exception ex)
            {
                this.logger.LogError("Error obteniendo ordenes", ex.ToString());
            }
           
            return orders;
        }

        public OrderModel GetOrderById(int id)
        {
            OrderModel orderModel = new OrderModel();

            try
            {
                Order order = this.GetEntity(id);
                orderModel.orderdate = order.orderdate;
                orderModel.requireddate = order.requireddate;
                orderModel.freight = order.freight;
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo ordenes", ex.ToString());
            }
            return orderModel;
        }

        public override void Add(Order entity)
        {

            if (this.Exists(cd => cd.orderid == entity.orderid))
            {
                throw new OrderException("Orden Existe");
            }

            base.SaveChanges();
        }

        public override void Update(Order entity)
        {
            Order orderToUpdate = this.GetEntity(entity.orderid);
            orderToUpdate.orderid = entity.orderid;
            orderToUpdate.orderdate = entity.orderdate;
            orderToUpdate.requireddate = entity.requireddate;
            orderToUpdate.freight = entity.freight;

            this.context.Orders.Update(orderToUpdate);
            this.context.SaveChanges();
        }

        public override void Delete(Order entity)
        {
            try
            {
                Order orderToDelete = this.GetEntity(entity.orderid);
                orderToDelete.deleted = entity.deleted;
                orderToDelete.delete_date = entity.delete_date;
                orderToDelete.delete_user = entity.delete_user;

                this.context.Orders.Update(orderToDelete);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error eliminando orden", ex.ToString());
            }
            base.SaveChanges();
        }
    }
}