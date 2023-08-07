﻿using shop.Web.Controllers.Extentions;
using shop.Application.Dtos.Order;
using shop.Web.Models.Core;
using shop.Web.Services.Caller;
using shop.Web.Models.Request;
using shop.Web.Models.Responses;

namespace shop.Web.Services
{
    public class OrderApiService : IOrderApiService
    {
        private readonly IApiServiceCaller apicaller;
        private readonly ILogger<OrderApiService> logger;
        private string baseUrl = "http://localhost:5016/api/Order/";


        public OrderApiService(IApiServiceCaller apicaller, ILogger<OrderApiService> logger)
        {
            this.apicaller = apicaller;
            this.logger = logger;
        }

        public OrderListResponse Get()
        {
            OrderListResponse? ordersList = new OrderListResponse();
            string url = $" {baseUrl}GetOrders";

            try
            {
                ordersList = apicaller.Get(url, ordersList);

                if (ordersList == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                ordersList = new OrderListResponse();
                ordersList.success = false;
                ordersList.message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(ordersList.message, ex.ToString());
            }

            return ordersList;
        }
        public OrderDetailResponse GetById(int id)
        {
            OrderDetailResponse? order = new OrderDetailResponse();
            string url = $" {baseUrl}/{id}";

            try
            {
                order = apicaller.Get(url, order);

                if (order == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                order = new OrderDetailResponse();
                order.success = false;
                order.message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(order.message, ex.ToString());
            }

            return order;
        }
        public BaseResponseD Add(OrderAddRequest add)
        {
            BaseResponseD? result = new BaseResponseD();

            OrderAddDto orderAdd = add.ConvertAddRequestToAddDto();

            string url = $" {baseUrl}Guardar";

            try
            {
                result = apicaller.Set(url, orderAdd, result);
                if (result == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                result = new BaseResponseD();
                result.success = false;
                result.message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(result.message, ex.ToString());
            }

            return result;
        }
        public BaseResponseD Update(OrderUpdateRequest update)
        {
            BaseResponseD? result = new BaseResponseD();

            OrderUpdateDto orderUpdate = update.ConvertirUpdateRequestToUpdateDto();
            string url = $" {baseUrl}Modificar";

            try
            {
                result = apicaller.Set(url, orderUpdate, result);
                if (result == null)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                result = new BaseResponseD();
                result.success = false;
                result.message = $"Error al solicitar al llamar Api, url:{url}";
                logger.LogError(result.message, ex.ToString());
            }

            return result;
        }

    }
}
