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
                    orderid = de.orderid,
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

        public override void Add(Order entity)
        {

            if (this.Exists(cd => cd.orderid == entity.orderid))
            {
                throw new OrderException("");
            }

            base.SaveChanges();
        }

        public override void Delete(Order entity)
        {
            if (this.Exists(cd => cd.orderid == entity.orderid))
            {
                throw new OrderException("");
            }

            base.SaveChanges();
        }

        public override void Update(Order entity)
        {
            base.Update(entity);
        }
    }
}