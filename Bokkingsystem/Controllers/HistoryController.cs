using Bokkingsystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bokkingsystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private IHisotry _repository;
        public HistoryController(IHisotry repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHistory()
        {
            try
            {
                return Ok(await _repository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Error to retrive data from database");
            }
        }
    }
}
