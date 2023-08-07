using Microsoft.AspNetCore.Mvc;
using shop.Application.Dtos.Order;
using shop.Infraestructure.Models;
using shop.Application.Contract;

namespace shop.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public ActionResult Index()
        {
            var result = orderService.Get();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
            }

            var Order = (List<OrderModel>)result.Data;

            return View(Order);
        }

        public ActionResult Details(int id)
        {
            var result = orderService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
            }

            var Order = (OrderModel)result.Data;

            return View(Order);
        }

        public ActionResult Create()
        {
            return View();
        }

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

        public ActionResult Edit(int id)
        {
            var result = orderService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
            }

            var order = (OrderModel)result.Data;

            return View(order);
        }

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
    }
}
