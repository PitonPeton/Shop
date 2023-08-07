using Newtonsoft.Json;
using shop.Web.Models.Core;
using System.Text;

namespace shop.Web.Services.Caller
{
    public class ApiServiceCaller : IApiServiceCaller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly ILogger<ApiServiceCaller> logger;

        public ApiServiceCaller(ILogger<ApiServiceCaller> logger)
        {
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
            this.logger = logger;
        }

        public ObjIn? Get<ObjIn>(string url, ObjIn objIn) where ObjIn : BaseResponseD
        {
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                using (var response = httpClient.GetAsync(url).Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        objIn = JsonConvert.DeserializeObject<ObjIn>(apiResponse);
                    }
                }
            }

            return objIn;
        }

        public ObjOut? Set<ObjIn, ObjOut>(string url, ObjIn objIn, ObjOut objOut) where ObjOut : BaseResponseD
        {
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(objIn), Encoding.UTF8, "application/json");

                using (var response = httpClient.PostAsync(url, content).Result)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    objOut = JsonConvert.DeserializeObject<ObjOut>(apiResponse);
                }

                return objOut;
            }
        }
    }
}
