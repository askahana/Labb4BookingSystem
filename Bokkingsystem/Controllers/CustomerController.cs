using Bokkingsystem.Models.Entities;
using Bokkingsystem.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bokkingsystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
       
    }
}
