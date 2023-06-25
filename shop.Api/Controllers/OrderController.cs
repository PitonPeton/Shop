using Microsoft.AspNetCore.Mvc;
using shop.Domain.Entities.Orders;
using shop.Application.Dtos.Order;
using shop.Infraestructure.Interfaces;
using shop.Domain.Entities.Shippers;

namespace shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult Get()
        {
            var orders = this.orderRepository.GetOrders();
            return Ok(orders);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = this.orderRepository.GetEntity(id);
            return Ok(order);
        }

        // POST api/<OrderController>
        [HttpPost("Save")]
        public IActionResult Post([FromBody] OrderAddDto orderAdd)
        {
            this.orderRepository.Add(new Order()
            {
                freight = (decimal)orderAdd.freight,
                creation_user = (int)orderAdd.change_user,
            });

            return Ok();
        }

        // PUT api/<OrderController>/5
        [HttpPut("Update")]
        public IActionResult Put(int id, [FromBody] OrderUpdateDto orderUpdate)
        {
            Order orderToUpdate = new Order()
            {
                orderid = orderUpdate.orderid,
                freight = (decimal)orderUpdate.freight,
                modify_user = orderUpdate.change_user,
                modify_date = DateTime.Now
            };

            this.orderRepository.Update(orderToUpdate);
            return Ok();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] OrderRemoveDto orderDelete)
        {
            Order orderToDelete = new Order()
            {
                orderid = orderDelete.orderid,
                deleted = orderDelete.deleted,
                delete_date = orderDelete.change_date,
                delete_user = orderDelete.change_user
            };

            this.orderRepository.Delete(orderToDelete);
            return Ok();
        }
    }
}

