using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using shop.Application.Contract;
using shop.Application.Dtos.Product;
using shop.WebApp.Models;


namespace shop.WebApp.Controllers
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

            var result = this.productService.Get();

            if (!result.Success)
            {
                ViewBag.Message = result.Message; 
                return View();
            }

            var products = ((List<Infraestructure.Models.ProductModel>)result.Data).Select(cd => new Models.ProductModel()
            {
                productid = cd.productid,
                productname = cd.productname,
                unitprice = cd.unitprice,
                discontinued = cd.discontinued,
                supplierid = cd.supplierid,
                categoryid = cd.categoryid
            }).ToList();

            return View(products);
        }
        public ActionResult Details(int id)
        {
            var result = this.productService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var product = (Infraestructure.Models.ProductModel)result.Data;

            var productmodel = new Models.ProductModel()
            {
                productid = product.productid,
                productname = product.productname,
                unitprice = product.unitprice,
                discontinued = product.discontinued,
                supplierid = product.supplierid,
                categoryid = product.categoryid
            };

            return View(productmodel);
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
            var result = this.productService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var product = (Infraestructure.Models.ProductModel)result.Data;

            var productmodel = new Models.ProductModel()
            {
                productid = product.productid,
                productname = product.productname,
                unitprice = product.unitprice,
                discontinued = product.discontinued,
                supplierid = product.supplierid,
                categoryid = product.categoryid
            };

            return (View(productmodel));
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
