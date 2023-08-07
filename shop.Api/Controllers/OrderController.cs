using Microsoft.AspNetCore.Mvc;
using shop.Application.Dtos.Order;
using shop.Application.Contract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("GetOrders")]
        public IActionResult Get()
        {
            var orders = this.orderService.Get();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = this.orderService.GetById(id);
            return Ok(order);
        }

        [HttpPost("Guardar")]
        public IActionResult Post([FromBody] OrderAddDto orderAdd)
        {
            var result = this.orderService.Save(orderAdd);
            return Ok(result);
        }

        [HttpPut("Modificar")]
        public IActionResult Put([FromBody] OrderUpdateDto orderUpdate)
        {
            var result = this.orderService.Update(orderUpdate);
            return Ok(result);
        }

        [HttpDelete("Borrar")]
        public IActionResult Delete([FromBody] OrderRemoveDto orderDelete)
        {
            var result = this.orderService.Delete(orderDelete);
            return Ok(result);
        }
    }
}

