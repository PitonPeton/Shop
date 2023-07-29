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
                orders = this.context.Orders
                            .Where(cd => !cd.Deleted)
                            .Select(de => new OrderModel()
                {
                    orderid = de.orderid,
                    custid = de.custid,
                    shipperid = de.shipperid,
                    empid = de.empid,
                    freight = de.freight,
                    requireddate = de.requireddate,
                    orderdate = de.orderdate               
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

                if (order == null)
                {
                    throw new OrderDataException("La orden no existe.");
                }

                orderModel.orderid = order.orderid;
                orderModel.empid = order.empid;
                orderModel.freight = order.freight;
                orderModel.requireddate = order.requireddate;
                orderModel.orderdate = order.orderdate;                
            }
            catch (OrderDataException dex)
            {
                throw new OrderDataException(dex.Message);
            }
            catch (Exception ex)
            {

                this.logger.LogError("Error obteniendo orden", ex.ToString());
            }
            return orderModel;
        }

        public override void Add(Order entity)
        {

            if (this.Exists(cd => cd.orderid == entity.orderid))
            {
                throw new OrderException("Orden Existe");
            }

            base.Add(entity);
            base.SaveChanges();
        }

        public override void Update(Order entity)
        {
            try
            {
                Order orderToUpdate = base.GetEntity(entity.orderid);

                orderToUpdate.orderid = entity.orderid;
                orderToUpdate.custid = entity.custid;
                orderToUpdate.empid = entity.empid;
                orderToUpdate.shipperid = entity.shipperid;
                orderToUpdate.freight = entity.freight;
                orderToUpdate.Modify_date = DateTime.Now;
                orderToUpdate.Modify_user = entity.Modify_user;

                base.Update(orderToUpdate);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error actualizando orden", ex.ToString());
            }
        }

        public override void Delete(Order entity)
        {
            try
            {
                Order orderToDelete = base.GetEntity(entity.orderid);

                if (orderToDelete == null)
                {
                    throw new OrderDataException("La orden no existe.");
                }

                orderToDelete.Deleted = true;
                orderToDelete.Delete_date = entity.Delete_date;
                orderToDelete.Delete_user = entity.Delete_user;

                base.Update(orderToDelete);
                base.SaveChanges();
            }
            catch (OrderDataException dex)
            {
                throw new OrderDataException(dex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error eliminando orden", ex.ToString());
            }
        }

        
    }
}

