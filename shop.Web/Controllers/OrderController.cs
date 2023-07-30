using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Application.Dtos.Order;
using shop.Application.Contract;
using shop.Domain.Entities.Orders;
using shop.Web.Models;

namespace shop.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            var result = this.orderService.Get();

            if (!result.Success)
            {
                ViewBag.Message = result.Message; 
                return View();
            }

            var orders = ((List<Infraestructure.Models.OrderModel>)result.Data).Select(cd => new Models.OrderModel()
            {
                orderid = cd.orderid,
                custid = cd.custid,
                shipperid = cd.shipperid,
                empid = cd.empid,
                freight = cd.freight,
                requireddate = cd.requireddate,
                orderdate = cd.orderdate
            }).ToList();

            return View(orders);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            var result = this.orderService.GetById(id);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var order = (Infraestructure.Models.OrderModel)result.Data;

            var ordermodel = new Models.OrderModel()
            {
                orderid = order.orderid,
                empid = order.empid,
                freight = order.freight,
                requireddate = order.requireddate,
                orderdate = order.orderdate
            };
            return View(ordermodel);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderAddDto orderAddDto)
        {
            try
            {
                var result = this.orderService.Save(orderAddDto);

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

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.orderService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var order = (Infraestructure.Models.OrderModel)result.Data;

            var ordermodel = new Models.OrderModel() 
            {
                orderid = order.orderid,
                shipperid = order.shipperid,
                custid = order.custid,
                empid = order.empid,
                freight = order.freight,
                requireddate = order.requireddate,
                orderdate = order.orderdate
            };
            return View(ordermodel);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderUpdateDto orderUpdateDto)
        {
            try
            {
                var result = this.orderService.Update(orderUpdateDto);

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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
