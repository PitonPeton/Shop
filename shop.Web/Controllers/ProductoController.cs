using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using shop.Application.Dtos.Product;
using shop.Infraestructure.Models;
using shop.Application.Contract;
using shop.Web.Models.Responses;
using System.Text;

namespace shop.Web.Controllers
{
    public class ProductoController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public ProductoController(IConfiguration configuration)
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }

        public ActionResult Index()
        {
            ProductListResponse productList = new ProductListResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = httpClient.GetAsync("http://localhost:5016/api/Product").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        productList = JsonConvert.DeserializeObject<ProductListResponse>(apiResponse);
                    }
                }
            }

            return View(productList.data);

        }

        public ActionResult Details(int id)
        {
           
            ProductDetailResponse productDetail = new ProductDetailResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = httpClient.GetAsync($"http://localhost:5016/api/Product/{id}").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        productDetail = JsonConvert.DeserializeObject<ProductDetailResponse>(apiResponse);
                    }
                }
            }

            return View(productDetail.data);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductAddDto productAddDto) 
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
            ProductDetailResponse productDetail = new ProductDetailResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = httpClient.GetAsync($"http://localhost:5016/api/Product/{id}").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        productDetail = JsonConvert.DeserializeObject<ProductDetailResponse>(apiResponse);
                    }
                }
            }

            return View(productDetail.data);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductUpdateDto productUpdateDto)
        {
            try
            {
                var productUpdateResponse = new ProductUpdateResponse();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(productUpdateDto), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync("http://localhost:5016/api/Product/Modificar", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            var result = JsonConvert.DeserializeObject<ProductUpdateResponse>(apiResponse);

                            if (!result.success)
                            {
                                ViewBag.Message = result.message;
                                return View();
                            }

                            return RedirectToAction(nameof(Index));

                        }
                        else
                        {
                            ViewBag.Message = "Error actualizando el producto";
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
