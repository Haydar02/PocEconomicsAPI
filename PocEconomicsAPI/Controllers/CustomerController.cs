using Microsoft.AspNetCore.Mvc;
using PocEconimics.Services;
using System.ComponentModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PocEconomicsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        
        // GET api/<CustomerController>/5
        [HttpPost("RegisterCustomer")]
        public async Task<IActionResult> RegisterCustomer(int customerNo)
        {
            try
            {
                if (customerNo <= 0)
                {
                    return BadRequest();
                }
                var result = await _customerService.GetCustomerAndSave(customerNo, "license", 0);
                if(result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch(InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        //// POST api/<CustomerController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CustomerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CustomerController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
