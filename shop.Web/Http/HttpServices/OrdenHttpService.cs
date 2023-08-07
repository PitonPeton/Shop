using shop.Web.Models.Responses;
using shop.Web.Models.Core;
using shop.Application.Dtos.Order;
using shop.Web.Controllers.Extentions;
using shop.Web.Models.Request;


namespace shop.Web.Http.HttpServices
{
    public class OrdenHttpService
    {

        private readonly IHttpCaller httpCaller;
        private readonly ILogger<OrdenHttpService> logger;
        private string baseUrl = string.Empty;

        public OrdenHttpService(IHttpCaller apiCaller,
                                IConfiguration configuration,
                                ILogger<OrdenHttpService> logger)
        {
            this.httpCaller = apiCaller;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"] + "Order/";
        }

        public OrderListResponse Get()
        {
            OrderListResponse? ordersList = new OrderListResponse();
            string url = $" {baseUrl}GetOrders";

            try
            {
                ordersList = httpCaller.Get(url, ordersList);

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

        public OrderDetailResponse GetById(int Id)
        {
            OrderDetailResponse? order = new OrderDetailResponse();
            string url = $" {baseUrl}GetOrders?id={Id}";

            try
            {
                order = httpCaller.Get(url, order);

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
                result = httpCaller.Set(url, orderAdd, result);
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
                result = httpCaller.Set(url, orderUpdate, result);
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
