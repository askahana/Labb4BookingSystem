using AutoMapper;
using Bokkingsystem.Services;
using BookingModels;
using BookingModels.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bokkingsystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IAppointment _repo;
        private IMapper _mapper;
        public AppointmentController(IAppointment repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            try
            {
                return Ok(await _repo.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to retrive data from database");
            }
        }
        [HttpGet("appointment/{appointmentId}")]
        public async Task<IActionResult> GetSingel(int appointmentId)
        {
            try
            {
                if (!await _repo.AppointmentExist(appointmentId))
                {
                    return NotFound($"Appointment with ID {appointmentId} was not found");
                }
                return Ok(await _repo.GetSingel(appointmentId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to retrive data from database");
            }
        }
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetAllAppointmentsByCustomer(int customerId)
        {
            try
            {
               if(! await _repo.CustomerExist(customerId))
               {
                    return NotFound($"ID with {customerId} was not found");
               }
                var infoByCusomteId = _mapper.Map<List<AppointmentDto>>(await _repo.GetAllByCustomerId(customerId));
                return Ok(infoByCusomteId);
                //return Ok(await _repo.GetAllByCustomerId(customerId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to retrive data from database");
            }
        }
        [HttpGet("company/{companyId}")]
        public async Task<IActionResult> GetAllAppointmentsByCompany(int companyId)
        {
            try
            {
                if (!await _repo.CompanyExist(companyId))
                {
                    return NotFound($"Company with ID {companyId} was not found.");
                }
                return Ok(await _repo.GetAllByCompanyId(companyId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to retrive data from database");
            }
        }

        [HttpGet("weekNumber")]
        public async Task<IActionResult> GetAllAppointmentsByWeek(int year, int week)
        {
            try
            {
                return Ok(await _repo.GetAllByWeek(year, week));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to retrive data from database");
            }
        }
        [HttpGet("month")]
        public async Task<IActionResult> GetAllAppointmentsByMonth(int year, int month, int companyId)
        {
            try
            {
                if (!await _repo.CompanyExist(companyId))
                {
                    return NotFound($"Company with ID {companyId} was not found.");
                }
                return Ok(await _repo.GetAllByMonth(year, month, companyId));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to retrive data from database");
            }
        }


    }
}
