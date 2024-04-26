using Microsoft.AspNetCore.Mvc;
using PocEconimics.Models.DTO.InvoiceDTO;
using PocEconimics.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PocEconomicsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
      
        private readonly IinvoiceService _invoiceService;

        public InvoiceController(IinvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        // GET: api/<EconomicApiController>
        [HttpGet("List of invoices")]
        public async Task<IActionResult> GetInvoiceList(DateTime fromDate , int customerNo)
        {
            try
            {
                var invoices = await _invoiceService.GetInvoiceList(fromDate, customerNo);
                return Ok(invoices);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EconomicApiController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            try
            {
                var invoice = await _invoiceService.GetInvoiceById(id);
                return Ok(invoice);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<EconomicApiController>
        [HttpPost("DownloadInvoices")]
        public async Task<IActionResult> DownloadÍnvoices( DateTime fromDate, int customerNo)
        {
            try
            {
               
                    await _invoiceService.DownloadInvoices(fromDate, customerNo);
                    return Ok("Invoices downloaded successfully");
                

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PUT api/<EconomicApiController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<EconomicApiController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
