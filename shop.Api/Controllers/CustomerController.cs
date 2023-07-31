using Microsoft.AspNetCore.Mvc;
using shop.Infraestructure.Interfaces;
using shop.Application.Dtos.Customer;
using shop.Domain.Entities.Customer;
using shop.Application.Service;
using shop.Application.Contract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = this.customerService.Get();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = this.customerService.GetById(id);
            return Ok(customer);
        }

        [HttpPost("Guardar")]
        public IActionResult Post([FromBody] CustomerAddDto customerAdd)
        { 
            var result = this.customerService.Save(customerAdd);
            return Ok(result);
        }

        [HttpPut("Modificar")]
        public IActionResult Put([FromBody] CustomerUpdateDto customerUpdate)
        {
            var result = this.customerService.Update(customerUpdate);
            return Ok(result);
        }

        [HttpDelete("Borrar")]
        public IActionResult Delete([FromBody] CustomerDeleteDto customerDelete)
        {
            var result = this.customerService.Delete(customerDelete);
            return Ok(result);
        }
    }
}
