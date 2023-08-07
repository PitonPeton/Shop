﻿using Microsoft.AspNetCore.Mvc;
using shop.Web.Models.Request;
using shop.Web.Models.Responses;
using shop.Web.Services;

namespace shop.Web.Controllers
{
    public class OrdenController : Controller
    {
        private readonly IOrderApiService orderApiService;
        public OrdenController(IOrderApiService orderApiService)
        {
            this.orderApiService = orderApiService;
        }

        // GET: OrdenController
        public ActionResult Index()
        {
            try
            {
                OrderListResponse orderList = new OrderListResponse();

                orderList = orderApiService.Get();

                if (!orderList.success)
                    throw new Exception(orderList.message);


                return View(orderList.data);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: OrdenController/Details/5
        public ActionResult Details(int id)
        {
            OrderDetailResponse orderdetail = new OrderDetailResponse();
            orderdetail = this.orderApiService.GetById(id);

            return View(orderdetail.data);
        }

        // GET: OrdenController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderAddRequest orderAdd)
        {
            try
            {
                var result = orderApiService.Add(orderAdd);

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
            OrderDetailResponse orderdetail = new OrderDetailResponse();
            orderdetail = this.orderApiService.GetById(id);

            return View(orderdetail.data);
        }

        // POST: OrdenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderUpdateRequest orderUpdate)
        {
            try
            {
                var result = orderApiService.Update(orderUpdate);

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
