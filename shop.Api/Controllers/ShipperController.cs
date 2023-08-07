using Microsoft.AspNetCore.Mvc;
using shop.Application.Dtos.Shipper;
using shop.Application.Contract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService shipperService;

        public ShipperController(IShipperService shipperService)
        {
            this.shipperService = shipperService;
        }

        [HttpGet("GetShippers")]
        public IActionResult Get()
        {
            var shippers = this.shipperService.Get();
            return Ok(shippers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var shipper = this.shipperService.GetById(id);
            return Ok(shipper);
        }

        [HttpPost("Guardar")]
        public IActionResult Post([FromBody] ShipperAddDto shipperAdd)
        {
            var result = this.shipperService.Save(shipperAdd);
            return Ok(result);
        }

        [HttpPut("Modificar")]
        public IActionResult Put([FromBody] ShipperUpdateDto shipperUpdate)
        {
            var result = this.shipperService.Update(shipperUpdate);
            return Ok(result);
        }

        [HttpDelete("Borrar")]
        public IActionResult Delete([FromBody] ShipperRemoveDto shipperDelete)
        {
            var result = this.shipperService.Delete(shipperDelete);
            return Ok(result);
        }
    }
}
