using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shop.Application.Dtos.Shipper;
using shop.Web.Models.Responses;
using System.Text;

namespace shop.Web.Controllers
{
    public class ExpedidosController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public ExpedidosController(IConfiguration configuration)
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }

        public ActionResult Index()
        {
            ShipperListResponse shipperList = new ShipperListResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = httpClient.GetAsync("http://localhost:5016/api/Shipper").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        shipperList = JsonConvert.DeserializeObject<ShipperListResponse>(apiResponse);
                    }
                }
            }

            return View(shipperList.data);

        }

        public ActionResult Details(int id)
        {

            ShipperDetailResponse shipperDetail = new ShipperDetailResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = httpClient.GetAsync($"http://localhost:5016/api/Shipper/{id}").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        shipperDetail = JsonConvert.DeserializeObject<ShipperDetailResponse>(apiResponse);
                    }
                }
            }

            return View(shipperDetail.data);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShipperAddDto ShipperAddDto)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ShipperDetailResponse shipperDetail = new ShipperDetailResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = httpClient.GetAsync($"http://localhost:5016/api/Shipper/{id}").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        shipperDetail = JsonConvert.DeserializeObject<ShipperDetailResponse>(apiResponse);
                    }
                }
            }

            return View(shipperDetail.data);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShipperUpdateDto ShipperUpdateDto)
        {
            try
            {
                var shipperUpdateResponse = new ShipperUpdateResponse();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(ShipperUpdateDto), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync("http://localhost:5016/api/Shipper/Modificar", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            var result = JsonConvert.DeserializeObject<ShipperUpdateResponse>(apiResponse);

                            if (!result.success)
                            {
                                ViewBag.Message = result.message;
                                return View();
                            }

                            return RedirectToAction(nameof(Index));

                        }
                        else
                        {
                            ViewBag.Message = "Error actualizando el Expedido";
                            return View();
                        }
                    }
                }
            }
            catch
            {
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection formCollection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
