using Newtonsoft.Json;
using shop.Application.Dtos.Order;
using shop.Application.Dtos.Shipper;
using shop.Infraestructure.Models;
using shop.Web.Controllers;
using shop.Web.Models.Responses;
using System.Text;

namespace shop.Web.Services
{
    public class OrderApiService : IOrderApiService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<OrderApiService> logger;
        private string baseUrl = string.Empty;
        public OrderApiService(IHttpClientFactory httpClientFactory,
                               IConfiguration configuration,
                               ILogger<OrderApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"];
        }

        public OrderDetailResponse GetOrder(int id)
        {
            OrderDetailResponse orderDetailResponse = new OrderDetailResponse();


            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($"{this.baseUrl}/Course/GetCourse?id={id}").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            orderDetailResponse = JsonConvert.DeserializeObject<OrderDetailResponse>(apiResponse);
                        }
                        else
                        {
                            // realizar x logica //
                            orderDetailResponse.success = false;
                            orderDetailResponse.message = "Error conectandose al api de curso";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                orderDetailResponse.success = false;
                orderDetailResponse.message = "Error obteniendo los cursos";
                this.logger.LogError($"{orderDetailResponse.message}", ex.ToString());

            }
            return orderDetailResponse;
        }

        public OrderListResponse GetOrders()
        {
            OrderListResponse orderResponse = new OrderListResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($"{this.baseUrl}/Course/GetCourses").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            orderResponse = JsonConvert.DeserializeObject<OrderListResponse>(apiResponse);
                        }
                        else
                        {
                            // realizar x logica //


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                orderResponse.success = false;
                orderResponse.message = "Error obteniendo los cursos";
                this.logger.LogError($"{orderResponse.message}", ex.ToString());

            }
            return orderResponse;
        }

        public OrderSaveResponse Save(OrderAddDto orderAddDto)
        {
            OrderSaveResponse orderSaveReponse = new OrderSaveResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(orderAddDto), Encoding.UTF8, "application/json");


                    using (var response = httpClient.PostAsync($"{this.baseUrl}/Course/Save", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            orderSaveReponse = JsonConvert.DeserializeObject<OrderSaveResponse>(apiResponse);
                        }
                        else
                        {

                            // realizar x logica //
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                orderSaveReponse.success = false;
                orderSaveReponse.message = "Error guardando el curso.";
                this.logger.LogError($"{orderSaveReponse.message}", ex.ToString());
            }
            return orderSaveReponse;
        }

        public OrderUpdateResponse Update(OrderUpdateDto orderUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
    public class OrderApiHttpClientService : IOrderApiService
    {
        public OrderDetailResponse GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public OrderListResponse GetOrders()
        {
            throw new NotImplementedException();
        }

        public OrderSaveResponse Save(OrderAddDto orderAddDto)
        {
            throw new NotImplementedException();
        }

        public OrderUpdateResponse Update(OrderUpdateDto orderUpdateDto)
        {
            throw new NotImplementedException();
        }
    }

}
