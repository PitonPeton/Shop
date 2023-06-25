using shop.Application.Core;
using shop.Application.Dtos.Order;
using shop.Domain.Entities.Orders;
using shop.Infraestructure.Exceptions;
using shop.Infraestructure.Interfaces;
using System;
using shop.Application.Contract;
using Microsoft.Extensions.Logging;

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
            catch (OrderDataException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
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
            if (!model.freight.HasValue)
            {
                result.Message = "El peso de transporte es requerido.";
                result.Success = false;
                return result;
            }
            if (model.freight <= 0)
            {
                result.Message = "El peso de transporte no puede ser 0";
                result.Success = false;
                return result;
            }
            if (!model.change_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
                return result;
            }
            try
            {
                this.orderRepository.Add(new Order()
                {
                    freight = (decimal)model.freight,
                    creation_user = (int)model.change_user,
                    creation_date = model.change_date
                });
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

            if (!model.freight.HasValue)
            {
                result.Message = "El peso de transporte es requerido.";
                result.Success = false;
                return result;
            }
            if (model.freight <= 0)
            {
                result.Message = "El peso de transporte no puede ser 0";
                result.Success = false;
                return result;
            }
            if (!model.change_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
                return result;
            }
            try
            {
                this.orderRepository.Update(new Order()
                {
                    orderid = model.orderid,
                    orderdate = model.orderdate,
                    requireddate = model.requireddate,
                    freight = (decimal)model.freight,
                    modify_user = model.change_user,
                    modify_date = DateTime.Now
                });
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

            if (!model.change_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
                return result;
            }
            try
            {
                this.orderRepository.Delete(new Order()
                {
                    orderid = model.orderid,
                    deleted = model.deleted,
                    delete_date = DateTime.Now,
                    delete_user = model.change_user.Value,
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
