using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using shop.Application.Dtos.Product;
using shop.Infraestructure.Models;
using shop.Application.Contract;
using shop.Web.Models.Responses;
using System.Text;
using shop.Web.Services;
using shop.Web.Models.Request;
using AutoMapper;

namespace shop.Web.Controllers
{
    public class ProductoController : Controller
    {
        //HttpClientHandler httpClientHandler = new HttpClientHandler();

        //public ProductoController(IConfiguration configuration)
        //{
        //    this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        //}

        private readonly IProductApiService productApiService;

        public ProductoController(IProductApiService productApiService)
        {
            this.productApiService = productApiService;
        }

        public ActionResult Index()
        {
            ProductListResponse productList = new ProductListResponse();

            productList = this.productApiService.GetProducts();

            //using (var httpClient = new HttpClient(this.httpClientHandler))
            //{
            //    using (var response = httpClient.GetAsync("http://localhost:5016/api/Product").Result)
            //    {
            //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            string apiResponse = response.Content.ReadAsStringAsync().Result;
            //            productList = JsonConvert.DeserializeObject<ProductListResponse>(apiResponse);
            //        }
            //    }
            //}

            return View(productList.data);

        }

        public ActionResult Details(int id)
        {
           
            ProductDetailResponse productDetail = new ProductDetailResponse();

            productDetail = this.productApiService.GetProduct(id);

            //using (var httpClient = new HttpClient(this.httpClientHandler))
            //{
            //    using (var response = httpClient.GetAsync($"http://localhost:5016/api/Product/{id}").Result)
            //    {
            //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            string apiResponse = response.Content.ReadAsStringAsync().Result;
            //            productDetail = JsonConvert.DeserializeObject<ProductDetailResponse>(apiResponse);
            //        }
            //    }
            //}

            return View(productDetail.data);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductSaveRequest productSave) 
        {

            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductSaveRequest, ProductAddDto>());
                var mapper = config.CreateMapper();

                var productAddDto = mapper.Map<ProductAddDto>(productSave);

                var result = productApiService.Save(productAddDto);
                if (result != null)
                {
                    ViewBag.message = result.message;
                    return View();
                }

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

            productDetail = this.productApiService.GetProduct(id);

            //using (var httpClient = new HttpClient(this.httpClientHandler))
            //{
            //    using (var response = httpClient.GetAsync($"http://localhost:5016/api/Product/{id}").Result)
            //    {
            //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            string apiResponse = response.Content.ReadAsStringAsync().Result;
            //            productDetail = JsonConvert.DeserializeObject<ProductDetailResponse>(apiResponse);
            //        }
            //    }
            //}

            return View(productDetail.data);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductUpdateRequest productUpdate)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductUpdateRequest, ProductUpdateDto>());
                var mapper = config.CreateMapper();

                var productUpdateDto = mapper.Map<ProductUpdateDto>(productUpdate);

                var result = productApiService.Update(productUpdateDto);
                if (result != null)
                {
                    ViewBag.message = result.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            //try
            //{
            //    var productUpdateResponse = new ProductUpdateResponse();

            //    using (var httpClient = new HttpClient(this.httpClientHandler))
            //    {
            //        StringContent content = new StringContent(JsonConvert.SerializeObject(productUpdateDto), Encoding.UTF8, "application/json");

            //        using (var response = httpClient.PostAsync("http://localhost:5016/api/Product/Modificar", content).Result)
            //        {
            //            if (response.IsSuccessStatusCode)
            //            {
            //                string apiResponse = response.Content.ReadAsStringAsync().Result;
            //                var result = JsonConvert.DeserializeObject<ProductUpdateResponse>(apiResponse);

            //                if (!result.success)
            //                {
            //                    ViewBag.Message = result.message;
            //                    return View();
            //                }

            //                return RedirectToAction(nameof(Index));

            //            }
            //            else
            //            {
            //                ViewBag.Message = "Error actualizando el producto";
            //                return View();
            //            }
            //        }
            //    }
            //}
            //catch
            //{
            //    return View();
            //}

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
