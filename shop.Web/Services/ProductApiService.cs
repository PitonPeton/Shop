using Newtonsoft.Json;
using shop.Application.Dtos.Product;
using shop.Web.Models.Extention;
using shop.Web.Models.Request;
using shop.Web.Models.Responses;
using System.Text;

namespace shop.Web.Services
{
    public class ProductApiService : IProductApiService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<ProductApiService> logger;
        private string baseUrl = string.Empty;
        public ProductApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<ProductApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:BaseUrl"];
        }

        public ProductDetailResponse GetProduct(int id)
        {
            ProductDetailResponse productDetail = new ProductDetailResponse();
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($"{this.baseUrl}/Product/{id}").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            productDetail = JsonConvert.DeserializeObject<ProductDetailResponse>(apiResponse);
                        }
                        else
                        {
                            productDetail.success = false;
                            productDetail.message = "Error conectandose al api";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                productDetail.success = false;
                productDetail.message = "Error obteniendo productos";
                this.logger.LogError($"{productDetail.message}", ex.ToString());
            }
            return productDetail;
        }

        public ProductListResponse GetProducts()
        {
            ProductListResponse productList = new ProductListResponse();
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($"{this.baseUrl}/Product").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            productList = JsonConvert.DeserializeObject<ProductListResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                productList.success = false;
                productList.message = "Error obteniendo los productos";
                this.logger.LogError($"{productList.message}", ex.ToString());
            }
            return productList; 
        }

        public ProductSaveRequest Save(ProductAddDto productAddDto)
        {
            ProductSaveRequest productSave = new ProductSaveRequest();

            try
            {
                productAddDto.change_user = 1;

                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(productAddDto), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync($"{this.baseUrl}/Product/Guardar", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            productSave = JsonConvert.DeserializeObject<ProductSaveRequest>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                productSave.success = false;
                productSave.message = "Error obteniendo los productos";
                this.logger.LogError($"{productSave.message}", ex.ToString());
            }
            return productSave;
        }

        public ProductUpdateRequest Update(ProductUpdateDto productUpdateDto)
        {
            throw new NotImplementedException();
        }
    } 
}
