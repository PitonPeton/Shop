using Microsoft.AspNetCore.Mvc;
using shop.Web.Models.Request;
using shop.Web.Models.Responses;
using shop.Web.Services;

namespace shop.Web.Controllers
{
    public class ExpedidosController : Controller
    {
        private readonly IShipperApiService shipperApiService;
        public ExpedidosController(IShipperApiService shipperApiService)
        {
            this.shipperApiService = shipperApiService;
        }

        // GET: ExpedidoController
        public ActionResult Index()
        {
            try
            {
                ShipperListResponse shipperList = new ShipperListResponse();

                shipperList = shipperApiService.Get();

                if (!shipperList.success)
                    throw new Exception(shipperList.message);


                return View(shipperList.data);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ExpedidoController/Details/5
        public ActionResult Details(int id)
        {
            ShipperDetailResponse shipperdetail = new ShipperDetailResponse();
            shipperdetail = this.shipperApiService.GetById(id);

            return View(shipperdetail.data);
        }

        // GET: ExpedidoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShipperAddRequest shipperAdd)
        {
            try
            {
                var result = shipperApiService.Add(shipperAdd);

                if (!result.success)
                {
                    ViewBag.Message = result.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        // GET: OrdenController/Edit/5
        public ActionResult Edit(int id)
        {
            ShipperDetailResponse shipperdetail = new ShipperDetailResponse();
            shipperdetail = this.shipperApiService.GetById(id);

            return View(shipperdetail.data);
        }

        // POST: OrdenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShipperUpdateRequest shipperUpdate)
        {
            try
            {
                var result = shipperApiService.Update(shipperUpdate);

                if (!result.success)
                {
                    ViewBag.Message = result.message;
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
