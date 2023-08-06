using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using shop.Application.Dtos.Customer;
using shop.Infraestructure.Models;
using shop.Application.Contract;

namespace shop.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public ActionResult Index()
        {
            var result = customerService.Get();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
            }

            var customer = (List<CustomerModel>)result.Data;

            return View(customer);
        }

        public ActionResult Details(int id)
        {
            var result = customerService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
            }

            var customer = (CustomerModel)result.Data;

            return View(customer);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerAddDto customerAddDto)
        {
            try
            {
                var result = this.customerService.Save(customerAddDto);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
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
            var result = customerService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
            }

            var customer = (CustomerModel)result.Data;

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerUpdateDto customerUpdateDto)
        {
            try
            {
                var result = this.customerService.Update(customerUpdateDto);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
