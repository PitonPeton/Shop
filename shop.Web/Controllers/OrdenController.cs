using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shop.Web.Models.Responses;
using shop.Web.Services;

namespace shop.Web.Controllers
{
    public class OrdenController : Controller
    {
        private readonly IOrderApiService orderApiService;

        //private readonly IHttpClientFactory httpClientFactory;
        //private readonly IConfiguration configuration;
        //private readonly ILogger<CursoController> logger;
        //private string baseUrl = string.Empty;
        public OrdenController(IOrderApiService orderApiService)
        {
            //this.httpClientFactory = httpClientFactory;
            //this.configuration = configuration;
            //this.logger = logger;
            //this.baseUrl = this.configuration["ApiConfig:baseUrl"];
            this.orderApiService = orderApiService;
        }
        // GET: CursoController
        public ActionResult Index()
        {
            OrderListResponse orderReponse = new OrderListResponse();


            orderReponse = this.orderApiService.GetOrders();

            //try
            //{
            //    using (var httpClient = this.httpClientFactory.CreateClient())
            //    {
            //        using (var response = httpClient.GetAsync($"{this.baseUrl}/Course/GetCourses").Result)
            //        {
            //            if (response.IsSuccessStatusCode)
            //            {
            //                string apiResponse = response.Content.ReadAsStringAsync().Result;
            //                courseReponse = JsonConvert.DeserializeObject<CourseListReponse>(apiResponse);
            //            }
            //            else
            //            {
            //                // realizar x logica //
            //                ViewBag.Message = courseReponse.message;
            //                return View();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    this.logger.LogError("Error obteniendo los cursos", ex.ToString());
            //    return View();
            //}


            return View(orderReponse.data);
        }

        // GET: CursoController/Details/5
        public ActionResult Details(int id)
        {
            OrderDetailResponse orderDetailResponse = this.orderApiService.GetOrder(id);


            //try
            //{
            //    using (var httpClient = this.httpClientFactory.CreateClient())
            //    {
            //        using (var response = httpClient.GetAsync($"{this.baseUrl}/Course/GetCourse?id={ id }").Result)
            //        {
            //            if (response.IsSuccessStatusCode)
            //            {
            //                string apiResponse = response.Content.ReadAsStringAsync().Result;
            //                courseDetailResponse = JsonConvert.DeserializeObject<CourseDetailResponse>(apiResponse);
            //            }
            //            else
            //            {
            //                // realizar x logica //
            //                ViewBag.Message = courseDetailResponse.message;
            //                return View();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    this.logger.LogError("Error obteniendo los cursos", ex.ToString());
            //    return View();
            //}

            return View(orderDetailResponse.data);
        }

        // GET: CursoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CursoController/Create
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

        // GET: CursoController/Edit/5
        public ActionResult Edit(int id)
        {
            OrderDetailResponse orderDetailResponse = new OrderDetailResponse();

            //try
            //{
            //    using (var httpClient = this.httpClientFactory.CreateClient())
            //    {
            //        using (var response = httpClient.GetAsync($"{this.baseUrl}/Course/GetCourse?id={id}").Result)
            //        {
            //            if (response.IsSuccessStatusCode)
            //            {
            //                string apiResponse = response.Content.ReadAsStringAsync().Result;
            //                courseDetailResponse = JsonConvert.DeserializeObject<CourseDetailResponse>(apiResponse);
            //            }
            //            else
            //            {
            //                // realizar x logica //
            //                ViewBag.Message = courseDetailResponse.message;
            //                return View();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    this.logger.LogError("Error obteniendo los cursos", ex.ToString());
            //    return View();
            //}

            return View(orderDetailResponse.data);
        }

        // POST: CursoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
