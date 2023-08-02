using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using shop.Application.Dtos.Product;
using shop.Infraestructure.Models;
using shop.Application.Contract;

namespace shop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public ActionResult Index()
        {
            var result = productService.Get();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
            }

            var product = (List<ProductModel>)result.Data;

            return View(product);
        }

        public ActionResult Details(int id)
        {
            var result = productService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
            }

            var product = (ProductModel)result.Data;

            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductAddDto productAddDto) 
        {
            try
            {
                var result = this.productService.Save(productAddDto);

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
            var result = productService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
            }

            var product = (ProductModel)result.Data;
            
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductUpdateDto productUpdateDto)
        {
            try
            {
                var result = this.productService.Update(productUpdateDto);

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
