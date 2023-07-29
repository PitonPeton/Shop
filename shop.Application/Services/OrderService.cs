using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Logging;
using shop.Application.Contract;
using shop.Application.Core;
using shop.Application.Dtos.Order;
using shop.Domain.Entities.Orders;
using shop.Infraestructure.Exceptions;
using shop.Infraestructure.Interfaces;
using System;
using shop.Infraestructure.Repositories;
using shop.Application.Extentions;

namespace shop.Application.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ILogger<OrderService> logger;
        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            this.orderRepository = orderRepository;
            this.logger = logger;
        }
        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.orderRepository.GetOrders();
            }
            catch (OrderException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las ordenes";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.orderRepository.GetOrderById(id);
            }
            catch (OrderDataException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la orden";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
        public ServiceResult Save(OrderAddDto model)
        {
            ServiceResult result = new ServiceResult();

            result = model.IsValidOrder();

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var order = model.ConvertDtoAddToEntity();

                this.orderRepository.Add(order);

                result.Message = "Orden agregada correctamente.";
            }
            catch (OrderDataException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando la orden.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult Update(OrderUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            result = model.IsValidOrder();

            if (!result.Success)
            {
                return result;
            }

            try
            {
                var order = model.ConvertDtoUpdateToEntity();

                this.orderRepository.Update(order);

                result.Message = "La orden se ha modificado correctamente.";
            }
            catch (OrderDataException dex)
            {
                result.Success = false;
                result.Message = dex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error modificando la orden.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult Delete(OrderRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            result = model.ValidUser();

            if (!result.Success)
            {
                return result;
            }

            try
            {
                this.orderRepository.Delete(new Order()
                {
                    orderid = model.orderid,
                    Deleted = model.Deleted,
                    Delete_date = DateTime.Now,
                    Delete_user = model.Change_user.Value,
                });

                result.Message = "Orden eliminada correctamente.";
            }
            catch (OrderDataException pex)
            {
                result.Success = false;
                result.Message = pex.Message;
                this.logger.LogError($"{result.Message}");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando la orden.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

    }
}
