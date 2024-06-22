using AutoMapper;
using Bokkingsystem.Models.DTOs;
using Bokkingsystem.Models.Entities;
using Bokkingsystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Numerics;

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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminCompanyPolicy")]
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminCompanyPolicy")]
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminCompanyCustomer5Policy")]
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
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to retrive data from database");
            }
        }
        [HttpGet("company/{companyId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminCompanyPolicy")]
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminCompanyPolicy")]
        public async Task<IActionResult> GetAllAppointmentsByWeek(int year, int week)
        {
            try
            {
                var appointments = await _repo.GetAllByWeek(year, week);
                if (appointments == null)
                {
                    return NotFound($"Appointments week {week} was not found.");
                }
                return Ok(await _repo.GetAllByWeek(year, week));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to retrive data from database");
            }
        }
        [HttpGet("customer/{customerId}/week/{year}/{week}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminCompanyPolicy")]
        public async Task<IActionResult> GetAllAppointmentsByWeekandId(int year, int week, int cusomterId)
        {
            try
            {
                var appointments = await _repo.GetAllByWeekAndCusomterID(year, week, cusomterId);
                if (appointments == null)
                {
                    return NotFound($"Appointments week {week} was not found.");
                }
                return Ok(new { Count = appointments.Count(), Appointments = appointments });
                //return Ok(appointments);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to retrive data from database");
            }
        }

        [HttpGet("month")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminCompanyPolicy")]
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
        [HttpDelete("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminCompanyCustomer5Policy")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            try
            {
                var appointmentToDelete = await _repo.GetSingel(id);
                if(appointmentToDelete == null)
                {
                    return NotFound($"Appointment with ID {id} was not found.");
                }
                await _repo.Delete(id);
                return Ok($"Appointment with ID {id} was deleted.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete data from databasen.");
            }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminCompanyCustomer5Policy")]
        public async Task<ActionResult<Appointment>> CreateNewAppointment(Appointment newAppointment)
        {
            try
            {
                if (newAppointment == null)
                {
                    return BadRequest("Appointment data is null");
                }
                newAppointment.CreatedDate = DateTime.Now;
                newAppointment.ModifiedDate = null;

                var result = await _repo.Add(newAppointment);
                return CreatedAtAction(nameof(GetSingel),
                    new { appointmentId = result.AppointmentId }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new appointment in the database.");
            }
        }

        [HttpPut("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AdminCompanyCustomer5Policy")]
        public async Task<ActionResult<Appointment>> UppdateAppointment(int appointmentId, Appointment appointment)
        {
            try
            {
                if(appointmentId != appointment.AppointmentId)
                {
                    return BadRequest("Id does not match.");
                }
                var appointmentToUpdate = await _repo.GetSingel(appointmentId);
                if(appointmentToUpdate == null)
                {
                    return NotFound($"Appointment with ID {appointmentId} was not found.");
                }
                return await _repo.Update(appointment);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error to update data into Database.");
            }

        }

    }
}
