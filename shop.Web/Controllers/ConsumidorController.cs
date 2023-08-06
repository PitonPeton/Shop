using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using shop.Web.Models.Reponses;
using shop.Web.Models.Responses;
using shop.Web.Services;

namespace shop.Web.Controllers
{
    public class ConsumidorController : Controller
    {
        private readonly ICustomerApiService customerApiService;

        public ConsumidorController(ICustomerApiService customerApiService )
        {
            this.customerApiService = customerApiService;
        }
     
        public ActionResult Index()
        {
            CustomerListResponse customerReponse = new CustomerListResponse();


            customerReponse = this.customerApiService.GetCustomers();

            return View(customerReponse.data);
        }

        public ActionResult Details(int id)
        {
            CustomerDetailResponse customerDetailResponse = this.customerApiService.GetCustomer(id);

            return View(customerDetailResponse.data);
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
            CustomerDetailResponse customerDetailResponse = new CustomerDetailResponse();

            return View(customerDetailResponse.data);
        }

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
