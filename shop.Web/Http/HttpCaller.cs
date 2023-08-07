using Newtonsoft.Json;
using shop.Web.Models.Core;
using System.Text;

namespace shop.Web.Http
{
    public class HttpCaller : IHttpCaller
    {
        private readonly IHttpClientFactory httpClienteFactory;
        private readonly ILogger<HttpCaller> logger;

        public HttpCaller(IHttpClientFactory httpClienteFactory, ILogger<HttpCaller> logger)
        {
            this.httpClienteFactory = httpClienteFactory;
            this.logger = logger;
        }

        public Response? Get<Response>(string url, Response? response) where Response : BaseResponseD
        {
            using (var httpClient = this.httpClienteFactory.CreateClient())
            {
                using (var result = httpClient.GetAsync(url).Result)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        string apiResponse = result.Content.ReadAsStringAsync().Result;
                        response = JsonConvert.DeserializeObject<Response>(apiResponse);
                    }
                }
            }
            return response;
        }

        public Response? Set<Request, Response>(string url, Request request, Response? response) where Response : BaseResponseD
        {
            using (var httpClient = this.httpClienteFactory.CreateClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

                using (var result = httpClient.PostAsJsonAsync(url, content).Result)
                {
                    if (result.IsSuccessStatusCode)
                    {
                        string apiResponse = result.Content.ReadAsStringAsync().Result;
                        response = JsonConvert.DeserializeObject<Response>(apiResponse);
                    }
                }
            }
            return response;
        }
    }
}
