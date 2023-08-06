using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shop.Application.Dtos.Customer;
using shop.Web.Models.Reponses;
using shop.Web.Models.Responses;
using System.Text;

namespace shop.Web.Controllers
{
    public class ClienteController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        public ClienteController(IConfiguration configuration)
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };

        }
        
        public ActionResult Index()
        {
            CustomerListResponse customerList = new CustomerListResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync("http://localhost:5016/api/Customer").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        customerList = JsonConvert.DeserializeObject<CustomerListResponse>(apiResponse);
                    }


                }
            }



            return View(customerList.data);
        }

        public ActionResult Details(int id)
        {
            CustomerDetailResponse customerDetail = new CustomerDetailResponse();
           
            
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync($"http://localhost:5016/api/Customer/{ id }").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        customerDetail = JsonConvert.DeserializeObject<CustomerDetailResponse>(apiResponse);
                    }


                }
            }



            return View(customerDetail.data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
            CustomerDetailResponse customerDetail = new CustomerDetailResponse();


            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync($"http://localhost:5016/api/Customer/{id}").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        customerDetail = JsonConvert.DeserializeObject<CustomerDetailResponse>(apiResponse);
                    }

                }
            }


            return View(customerDetail.data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerUpdateDto customerUpdateDto)
        {
            try
            {
                var customerUpdateResponse = new CustomerUpdateResponse();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {

                    StringContent content = new StringContent(JsonConvert.SerializeObject(customerUpdateDto), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync("http://localhost:5016/api/Customer/Update", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            var result = JsonConvert.DeserializeObject<CustomerUpdateResponse>(apiResponse);

                            if (!result.success)
                            {
                                ViewBag.Message = result.message;
                                return View();
                            }
                            return RedirectToAction(nameof(Index));

                        }
                        else
                        {
                            ViewBag.Message = "Error actualizando el cliente";
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

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
