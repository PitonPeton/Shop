using Microsoft.AspNetCore.Mvc;
using shop.Domain.Entities.Shippers;
using shop.Infraestructure.Interfaces;
using shop.Application.Dtos.Shipper;

namespace shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperRepository shipperRepository;

        public ShipperController(IShipperRepository shipperRepository)
        {
            this.shipperRepository = shipperRepository;
        }

        // GET: api/<shipperController>
        [HttpGet]
        public IActionResult Get()
        {
            var shippers = this.shipperRepository.GetShippers();
            return Ok(shippers);
        }

        // GET api/<shipperController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var shipper = this.shipperRepository.GetEntity(id);
            return Ok(shipper);
        }

        // POST api/<shipperController>
        [HttpPost("Save")]
        public IActionResult Post([FromBody] ShipperAddDto shipperAdd)
        {
            this.shipperRepository.Add(new Shipper()
            {
                companyname = shipperAdd.companyname,
                phone = shipperAdd.phone,
                shipname = shipperAdd.shipname,
                shipaddress = shipperAdd.shipaddress,
                shipcity = shipperAdd.shipcity,
                shipregion = shipperAdd.shipregion,
                shippeddate = shipperAdd.shippeddate,
                shipcountry = shipperAdd.shipcountry,
                creation_user = (int)shipperAdd.change_user,
                creation_date = shipperAdd.change_date
            });

            return Ok();
        }

        // PUT api/<shipperController>/5
        [HttpPut("Update")]
        public IActionResult Put(int id, [FromBody] ShipperUpdateDto shipperUpdate)
        {
            Shipper shipperToUpdate = new Shipper()
            {
                shipperid = shipperUpdate.shipperid,
                companyname = shipperUpdate.companyname,
                phone = shipperUpdate.phone,
                shipname = shipperUpdate.shipname,
                shipaddress = shipperUpdate.shipaddress,
                shipcity = shipperUpdate.shipcity,
                shipregion = shipperUpdate.shipregion,
                shippeddate = shipperUpdate.shippeddate,
                shipcountry = shipperUpdate.shipcountry,
                modify_user = shipperUpdate.change_user,
                modify_date = DateTime.Now
            };

            this.shipperRepository.Update(shipperToUpdate);
            return Ok();
        }

        // DELETE api/<shipperController>/5
        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] ShipperRemoveDto shipperDelete)
        {
            Shipper shipperToDelete = new Shipper()
            {
                shipperid = shipperDelete.shipperid,
                deleted = shipperDelete.deleted,
                delete_date = shipperDelete.change_date,
                delete_user = shipperDelete.change_user
            };

            this.shipperRepository.Delete(shipperToDelete);
            return Ok();
        }
    }
}
