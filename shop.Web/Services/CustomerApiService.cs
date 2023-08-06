using Newtonsoft.Json;
using shop.Application.Dtos.Customer;
using shop.Infraestructure.Models;
using shop.Web.Controllers;
using shop.Web.Models.Reponses;

using shop.Web.Models.Responses;
using System.Text;

namespace shop.Web.Services
{
    public class CustomerApiService : ICustomerApiService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<CustomerApiService> logger;
        private string baseUrl = string.Empty;
        public CustomerApiService(IHttpClientFactory httpClientFactory,
                               IConfiguration configuration,
                               ILogger<CustomerApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"];
        }

        public CustomerDetailResponse GetCustomer(int id)
        {
            CustomerDetailResponse customerDetailResponse = new CustomerDetailResponse();


            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($"{this.baseUrl}/Customer/GetCustomer?id={id}").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            customerDetailResponse = JsonConvert.DeserializeObject<CustomerDetailResponse>(apiResponse);
                        }
                        else
                        {
                            customerDetailResponse.success = false;
                            customerDetailResponse.message = "Error conectandose al api de cliente";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                customerDetailResponse.success = false;
                customerDetailResponse.message = "Error obteniendo los cliente";
                this.logger.LogError($"{customerDetailResponse.message}", ex.ToString());

            }
            return customerDetailResponse;
        }

        public CustomerListResponse GetCustomers()
        {
            CustomerListResponse customerReponse = new CustomerListResponse();

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($"{this.baseUrl}/Customer/GetCustomers").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            customerReponse = JsonConvert.DeserializeObject<CustomerListResponse>(apiResponse);
                        }
                      
                    }
                }
            }
            catch (Exception ex)
            {
                customerReponse.success = false;
                customerReponse.message = "Error obteniendo los clientes";
                this.logger.LogError($"{customerReponse.message}", ex.ToString());

            }
            return customerReponse;
        }

        public CustomerSaveReponse Save(CustomerAddDto customerAddDto)
        {
            CustomerSaveReponse customerSave = new CustomerSaveReponse();

            try
            {
                customerAddDto.change_user = 1;

                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(customerAddDto), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync($"{this.baseUrl}/Customer/Guardar", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            customerSave = JsonConvert.DeserializeObject<CustomerSaveReponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                customerSave.success = false;
                customerSave.message = "Error guardando el cliente";
                this.logger.LogError($"{customerSave.message}", ex.ToString());
            }
            return customerSave;
        }

        public CustomerUpdateResponse Update(CustomerUpdateDto customerUpdateDto)
        {

            CustomerUpdateResponse customerUpdate = new CustomerUpdateResponse();

            try
            {
                customerUpdateDto.change_user = 1;

                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(customerUpdateDto), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync($"{this.baseUrl}/Customer/Modificar", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            customerUpdate = JsonConvert.DeserializeObject<CustomerUpdateResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                customerUpdate.success = false;
                customerUpdate.message = "Error modificando el cliente";
                this.logger.LogError($"{customerUpdate.message}", ex.ToString());
            }
            return customerUpdate;
        }
    }

}
