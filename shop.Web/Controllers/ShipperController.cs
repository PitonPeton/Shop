using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using shop.Application.Dtos.Shipper;
using shop.Infraestructure.Models;
using shop.Application.Contract;

namespace shop.Web.Controllers
{
    public class ShipperController : Controller
    {
        private readonly IShipperService shipperService;

        public ShipperController(IShipperService shipperService)
        {
            this.shipperService = shipperService;
        }

        public ActionResult Index()
        {
            var result = shipperService.Get();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
            }

            var shipper = (List<ShipperModel>)result.Data;

            return View(shipper);
        }

        public ActionResult Details(int id)
        {
            var result = shipperService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
            }

            var shipper = (ShipperModel)result.Data;

            return View(shipper);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShipperAddDto shipperAddDto)
        {
            try
            {
                var result = this.shipperService.Save(shipperAddDto);

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
            var result = shipperService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
            }

            var shipper = (ShipperModel)result.Data;

            return View(shipper);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ShipperUpdateDto shipperUpdateDto)
        {
            try
            {
                var result = this.shipperService.Update(shipperUpdateDto);

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
