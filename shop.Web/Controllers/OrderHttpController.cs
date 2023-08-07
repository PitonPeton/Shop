using shop.Web.Services;
using shop.Web.Models.Request;
using shop.Web.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace shop.Web.Controllers
{
    public class OrderHttpController : Controller
    {
            private readonly IOrderApiService orderHttpService;
            public OrderHttpController(IOrderApiService orderHttpService)
            {
                this.orderHttpService = orderHttpService;
            }
            // GET: OrderHttpController
            public ActionResult Index()
            {
                try
                {
                    OrderListResponse orderList = new OrderListResponse();

                    orderList = orderHttpService.Get();

                    if (!orderList.success)
                        throw new Exception(orderList.message);


                    return View(orderList.data);
                }
                catch (Exception e)
                {
                    ViewBag.message = e.Message;
                    return RedirectToAction(nameof(Index));
                }

            }

            // GET: OrderHttpController/Details/5
            public ActionResult Details(int id)
            {
                try
                {
                    OrderDetailResponse usuario = new OrderDetailResponse();

                    usuario = orderHttpService.GetById(id);

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

            // GET: OrderHttpController/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: OrderHttpController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(OrderAddRequest orderAdd)
            {
                try
                {
                    var result = orderHttpService.Add(orderAdd);

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

            // GET: OrderHttpController/Edit/5
            public ActionResult Edit(int id)
            {
                OrderDetailResponse orderdetail = new OrderDetailResponse();
                orderdetail = this.orderHttpService.GetById(id);

                return View(orderdetail.data);
            }

            // POST: OrderHttpController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit(int id, OrderUpdateRequest orderUpdate)
            {
                try
                {
                    var result = orderHttpService.Update(orderUpdate);

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

