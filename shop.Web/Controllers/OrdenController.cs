using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using shop.Application.Dtos.Order;
using shop.Infraestructure.Models;
using shop.Application.Contract;
using shop.Web.Models.Responses;
using System.Text;

namespace shop.Web.Controllers
{
    public class OrdenController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public OrdenController(IConfiguration configuration)
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }

        public ActionResult Index()
        {
            OrderListResponse orderList = new OrderListResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = httpClient.GetAsync("http://localhost:5016/api/Order").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        orderList = JsonConvert.DeserializeObject<OrderListResponse>(apiResponse);
                    }
                }
            }

            return View(orderList.data);

        }

        public ActionResult Details(int id)
        {

            OrderDetailResponse orderDetail = new OrderDetailResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = httpClient.GetAsync($"http://localhost:5016/api/Order/{id}").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        orderDetail = JsonConvert.DeserializeObject<OrderDetailResponse>(apiResponse);
                    }
                }
            }

            return View(orderDetail.data);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderAddDto OrderAddDto)
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
            OrderDetailResponse orderDetail = new OrderDetailResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = httpClient.GetAsync($"http://localhost:5016/api/Order/{id}").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        orderDetail = JsonConvert.DeserializeObject<OrderDetailResponse>(apiResponse);
                    }
                }
            }

            return View(orderDetail.data);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderUpdateDto OrderUpdateDto)
        {
            try
            {
                var orderUpdateResponse = new OrderUpdateResponse();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(OrderUpdateDto), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync("http://localhost:5016/api/Order/Modificar", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            var result = JsonConvert.DeserializeObject<OrderUpdateResponse>(apiResponse);

                            if (!result.success)
                            {
                                ViewBag.Message = result.message;
                                return View();
                            }

                            return RedirectToAction(nameof(Index));

                        }
                        else
                        {
                            ViewBag.Message = "Error actualizando el Orden";
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
