using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using shop.Application.Contract;
using shop.Application.Dtos.Customer;
using shop.WebApp.Models;

namespace shop.WebApp.Controllers
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

            var result = this.customerService.Get();

            if (!result.Success)
            {
                ViewBag.Message = result.Message; 
                return View();
            }

            var customers = ((List<Infraestructure.Models.CustomerModel>)result.Data).Select(cd => new Models.CustomerModel()
            {
                custid = cd.custid,
                companyname = cd.companyname,
                contactname = cd.contactname,
                contacttitle = cd.contacttitle,
                address = cd.address,
                email = cd.email,
                city = cd.city,
                region = cd.region,
                postalcode = cd.postalcode,
                country = cd.country,
                phone = cd.phone,
                fax = cd.fax
            }).ToList();

            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var result = this.customerService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var customer = (Infraestructure.Models.CustomerModel)result.Data;

            var customermodel = new Models.CustomerModel()
            {
                custid = customer.custid,
                companyname = customer.companyname,
                contactname = customer.contactname,
                contacttitle = customer.contacttitle,
                email = customer.email,
                fax = customer.fax,
                address = customer.address,
                city = customer.city,
                region = customer.region,
                postalcode = customer.postalcode,
                country = customer.country,
                phone = customer.phone
        };

            return View(customermodel);
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
            var result = this.customerService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var customer = (Infraestructure.Models.CustomerModel)result.Data;

            var customermodel = new Models.CustomerModel()
            {
                custid = customer.custid,
                companyname = customer.companyname,
                contactname = customer.contactname,
                contacttitle = customer.contacttitle,
                email = customer.email,
                fax = customer.fax,
                address = customer.address,
                city = customer.city,
                region = customer.region,
                postalcode = customer.postalcode,
                country = customer.country,
                phone = customer.phone
            };

            return (View(customermodel));
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
