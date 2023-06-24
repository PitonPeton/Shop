using Microsoft.AspNetCore.Mvc;
using shop.Infraestructure.Interfaces;
using shop.Application.Dtos.Product;
using shop.Domain.Entities.Products;
using shop.Application.Service;
using shop.Application.Contract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = this.productService.Get();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = this.productService.GetById(id);
            return Ok(product);
        }

        [HttpPost("Guardar")]
        public IActionResult Post([FromBody] ProductAddDto productAdd)
        { 
            var result = this.productService.Save(productAdd);
            return Ok(result);
        }

        [HttpPut("Modificar")]
        public IActionResult Put([FromBody] ProductUpdateDto productUpdate)
        {
            var result = this.productService.Update(productUpdate);
            return Ok(result);
        }

        [HttpDelete("Borrar")]
        public IActionResult Delete([FromBody] ProductDeleteDto productDelete)
        {
            var result = this.productService.Delete(productDelete);
            return Ok(result);
        }
    }
}
