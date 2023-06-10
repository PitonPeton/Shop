using Microsoft.AspNetCore.Mvc;
using shop.Infraestructure.Interfaces;
using shop.Application.Dtos.Customer;
using shop.Domain.Entities.Customer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customer = this.customerRepository.GetCustomer();
            return Ok(customer);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = this.customerRepository.GetEntity(id);
            return Ok(customer);
        }

        [HttpPost("Guardar")]
        public IActionResult Post([FromBody] CustomerAddDtop customerAdd)
        {
            this.customerRepository.Add(new Customer()
            {
                companyname = customerAdd.companyname,
                contactname = customerAdd.contactname,
                contacttitle = customerAdd.contacttitle,
                email = customerAdd.email,
                fax = customerAdd.fax,
                
                creation_date = customerAdd.change_date,
                creation_user = customerAdd.change_user
            });
            return Ok();
        }

        [HttpPut("Modificar")]
        public IActionResult Put([FromBody] CustomerUpdateDto customerUpdate)
        {
            Customer customerToUpdate = new Customer()
            {
                custid = customerUpdate.custid,
                companyname = customerUpdate.companyname,
                contactname = customerUpdate.contactname,
                contacttitle = customerUpdate.contacttitle,
                email = customerUpdate.email,
                fax = customerUpdate.fax,
                modify_date = DateTime.Now,
                modify_user = customerUpdate.change_user
            };
            
            this.customerRepository.Update(customerToUpdate);
            return Ok();
        }

        [HttpDelete("Borrar")]
        public IActionResult Delete([FromBody] CustomerDeleteDto customerDelete)
        {   
            Customer customerToDelete = new Customer()
            {
                custid = customerDelete.custid,
                deleted = customerDelete.deleted,
                delete_date = customerDelete.change_date,
                delete_user = customerDelete.change_user,
            };

            this.customerRepository.Delete(customerToDelete);
            return Ok();
        }
    }
}
