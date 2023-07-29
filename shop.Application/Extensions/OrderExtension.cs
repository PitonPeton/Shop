using shop.Application.Core;
using shop.Application.Dtos.Order;
using shop.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace shop.Application.Extentions
{
    public static class OrderExtention
    {
        public static ServiceResult ValidUser(this OrderRemoveDto model)
        {
            ServiceResult result = new ServiceResult();

            if (!model.Change_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
                return result;
            }

            return result;
        }
        public static ServiceResult IsValidOrder(this OrderDto model)
        {
            ServiceResult result = new ServiceResult();

            if (model.freight <= 0)
            {
                result.Message = "El gasto de transporte es requerido.";
                result.Success = false;
                return result;
            }
            if (model.shipperid <= 0)
            {
                result.Message = "Se requiere la id del expedido.";
                result.Success = false;
                return result;
            }
            if (!model.custid.HasValue)
            {
                result.Message = "Se requiere la id del cliente.";
                result.Success = false;
                return result;
            }
            if (!model.empid.HasValue)
            {
                result.Message = "Se requiere la id del empleado.";
                result.Success = false;
                return result;
            }
            if (!model.Change_user.HasValue)
            {
                result.Message = "Se requiere un usuario.";
                result.Success = false;
                return result;
            }

            return result;
        }
        public static Order ConvertDtoAddToEntity(this OrderAddDto orderAddDto)
        {
            return new Order()
            {
                empid = orderAddDto.empid.Value,
                custid = orderAddDto.custid.Value,
                shipperid = orderAddDto.shipperid.Value,
                freight = orderAddDto.freight.Value,
                Creation_user = orderAddDto.Change_user.Value,
                requireddate = orderAddDto.requireddate,
                orderdate = orderAddDto.orderdate,
                Creation_date = DateTime.Now
            };
        }
        public static Order ConvertDtoUpdateToEntity(this OrderUpdateDto orderUpdateDto)
        {
            return new Order()
            {
                orderid = orderUpdateDto.orderid,
                empid = orderUpdateDto.empid.Value,
                custid = orderUpdateDto.custid.Value,
                shipperid = orderUpdateDto.shipperid.Value,
                freight = orderUpdateDto.freight.Value,
                Modify_user = orderUpdateDto.Change_user.Value,
                requireddate = orderUpdateDto.requireddate,
                orderdate = orderUpdateDto.orderdate,
                Modify_date = DateTime.Now
            };
        }
    }
}
