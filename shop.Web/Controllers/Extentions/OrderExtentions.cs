using shop.Web.Models;
using shop.Application.Dtos.Order;
using shop.Infraestructure.Models;
using shop.Web.Models.Request;

namespace shop.Web.Controllers.Extentions
{
    public static class OrderExtentions
    {
        public static OrderResponseModel ConvertGetByIdToOrderResponse(this OrderModel order)
        {
            return new OrderResponseModel()
            {
                orderid = order.orderid,
                shipperid = order.shipperid,
                empid = order.empid,
                custid = order.custid,
                freight = order.freight,
                requireddate = order.requireddate,
                orderdate = order.orderdate,

            };
        }

        public static OrderAddDto ConvertAddRequestToAddDto(this OrderAddRequest orderAdd)
        {
            return new OrderAddDto()
            {
                shipperid = orderAdd.shipperid,
                empid = orderAdd.empid,
                custid = orderAdd.custid,
                freight = orderAdd.freight,
                requireddate = orderAdd.requireddate,
                orderdate = orderAdd.orderdate,
                Change_user = orderAdd.Change_user,
                Change_date = orderAdd.Change_date
            };
        }

        public static OrderUpdateRequest ConvertOrderToUpdateRequest(this OrderModel order)
        {
            return new OrderUpdateRequest()
            {
                orderid = order.orderid,
                shipperid = order.shipperid,
                empid = order.empid,
                custid = order.custid,
                freight = order.freight,

            };
        }

        public static OrderUpdateDto ConvertirUpdateRequestToUpdateDto(this  OrderUpdateRequest orderUpdate)
        {
            return new OrderUpdateDto()
            {
                orderid = orderUpdate.orderid,
                shipperid = orderUpdate.shipperid,
                empid = orderUpdate.empid,
                custid = orderUpdate.custid,
                freight = orderUpdate.freight,
                Change_user = orderUpdate.Change_user,
                Change_date = orderUpdate.Change_date,
            };
        }
    }
}