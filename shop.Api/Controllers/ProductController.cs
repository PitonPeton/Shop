using Microsoft.AspNetCore.Mvc;
using shop.Infraestructure.Interfaces;
using shop.Application.Dtos.Product;
using shop.Domain.Entities.Products;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = this.productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = this.productRepository.GetEntity(id);
            return Ok(product);
        }

        [HttpPost("Guardar")]
        public IActionResult Post([FromBody] ProductAddDtop productAdd)
        {
            this.productRepository.Add(new Product()
            {
                productname = productAdd.productname,
                unitprice = productAdd.unitprice,
                categoryid = 1,
                supplierid = 1,
                creation_date = DateTime.Now,
                creation_user = productAdd.change_user
            });
            return Ok();
        }

        [HttpPut("Modificar")]
        public IActionResult Put([FromBody] ProductUpdateDto productUpdate)
        {
            Product productToUpdate = new Product()
            {
                productid = productUpdate.productid,
                productname = productUpdate.productname,
                unitprice = productUpdate.unitprice,
                discontinued = productUpdate.discontinued,
                categoryid = productUpdate.categoryid,
                supplierid = productUpdate.supplierid,
                modify_date = DateTime.Now,
                modify_user = productUpdate.change_user
            };
            
            this.productRepository.Update(productToUpdate);
            return Ok();
        }

        [HttpDelete("Borrar")]
        public IActionResult Delete([FromBody] ProductDeleteDto productDelete)
        {   
            Product productToDelete = new Product()
            {
                productid = productDelete.productid,
                deleted = productDelete.deleted,
                delete_date = DateTime.Now,
                delete_user = productDelete.change_user,
            };

            this.productRepository.Delete(productToDelete);
            return Ok();
        }
    }
}
