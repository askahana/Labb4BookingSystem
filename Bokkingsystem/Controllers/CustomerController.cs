using Bokkingsystem.Models.Entities;
using Bokkingsystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bokkingsystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminCompanyPolicy")]
    public class CustomerController : ControllerBase
    {
        private IBooking<Customer> _repo;
        public CustomerController(IBooking<Customer> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                return Ok(await _repo.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to get Data from Database.");
            }
        }
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminCompanyCustomerPolicy")]
        public async Task<ActionResult<Customer>> GetSingel(int id)
        {
            try
            {
                var result = await _repo.GetSingel(id);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to Retrive Data from Database.......");
            }
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminCompanyCustomerPolicy")]
        public async Task<ActionResult<Customer>> CreateNewCustomer(Customer NewCustomer)
        {
            try
            {
                if (NewCustomer == null)
                {
                    return BadRequest();
                }
                var CreatedOrder = await _repo.Add(NewCustomer);
                return CreatedAtAction(nameof(GetSingel),
                    new { id = CreatedOrder.CustomerId }, CreatedOrder);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to Post Data To Database.");
            }
        }

    }
}
