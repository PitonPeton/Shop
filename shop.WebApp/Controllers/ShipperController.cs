using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using shop.Application.Contract;
using shop.Application.Dtos.Shipper;
using shop.WebApp.Models;

namespace shop.WebApp.Controllers
{
    public class ShipperController : Controller
    {
        private readonly IShipperService shipperService;

        public ShipperController(IShipperService shipperService)
        {
            this.shipperService = shipperService;
        }

        // GET: ShipperController
        public ActionResult Index()
        {
            var result = this.shipperService.Get();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var shippers = ((List<Infraestructure.Models.ShipperModel>)result.Data).Select(cd => new Models.ShipperModel()
            {
                shipperid = cd.shipperid,
                companyname = cd.companyname,
                phone = cd.phone,
                shipname = cd.shipname,
                shipaddress = cd.shipaddress,
                shipcity = cd.shipcity,
                shippostalcode = cd.shippostalcode,
                shipregion = cd.shipregion,
                shipcountry = cd.shipcountry,
                shippeddate = cd.shippeddate,
            }).ToList();

            return View(shippers);
        }

        // GET: ShipperController/cdtails/5
        public ActionResult Details(int id)
        {
            var result = this.shipperService.GetById(id);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var shipper = (Infraestructure.Models.ShipperModel)result.Data;

            var shippermodel = new Models.ShipperModel()
            {
                shipperid = shipper.shipperid,
                companyname = shipper.companyname,
                phone = shipper.phone,
                shippeddate = shipper.shippeddate,
                shipcountry = shipper.shipcountry,
            };

            return View(shippermodel);
        }

        // GET: ShipperController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShipperController/Create
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

        // GET: ShipperController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.shipperService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var shipper = (Infraestructure.Models.ShipperModel)result.Data;

            var shippermodel = new Models.ShipperModel() 
            {
                shipperid = shipper.shipperid,
                companyname = shipper.companyname,
                phone = shipper.phone,
                shipname = shipper.shipname,
                shipaddress = shipper.shipaddress,
                shipcity = shipper.shipcity,
                shipregion = shipper.shipregion,
                shippostalcode = shipper.shippostalcode,
                shippeddate = shipper.shippeddate,
                shipcountry = shipper.shipcountry
            };

            return View(shippermodel);
        }

        // POST: ShipperController/Edit/5
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

        // GET: ShipperController/cdlete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShipperController/cdlete/5
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
