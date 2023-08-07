using Microsoft.AspNetCore.Mvc;
using shop.Web.Models.Request;
using shop.Web.Models.Responses;
using shop.Web.Services;

namespace shop.Web.Controllers
{
    public class ShipperHttpController : Controller
    {
        private readonly IShipperApiService shipperHttpService;
        public ShipperHttpController(IShipperApiService shipperHttpService)
        {
            this.shipperHttpService = shipperHttpService;
        }
        // GET: ShipperHttpController
        public ActionResult Index()
        {
            try
            {
                ShipperListResponse shipperList = new ShipperListResponse();

                shipperList = shipperHttpService.Get();

                if (!shipperList.success)
                    throw new Exception(shipperList.message);


                return View(shipperList.data);
            }
            catch (Exception e)
            {
                ViewBag.message = e.Message;
                return RedirectToAction(nameof(Index));
            }

        }

        // GET: ShipperHttpController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                ShipperDetailResponse usuario = new ShipperDetailResponse();

                usuario = shipperHttpService.GetById(id);

                if (!usuario.success)
                    throw new Exception(usuario.message);


                return View(usuario.data);
            }
            catch (Exception e)
            {
                ViewBag.message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ShipperHttpController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShipperHttpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShipperAddRequest orderAdd)
        {
            try
            {
                var result = shipperHttpService.Add(orderAdd);

                if (!result.success)
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

        // GET: ShipperHttpController/Edit/5
        public ActionResult Edit(int id)
        {
            ShipperDetailResponse shipperdetail = new ShipperDetailResponse();
            shipperdetail = this.shipperHttpService.GetById(id);

            return View(shipperdetail.data);
        }

        // POST: ShipperHttpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShipperUpdateRequest orderUpdate)
        {
            try
            {
                var result = shipperHttpService.Update(orderUpdate);

                if (!result.success)
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
    }
}
