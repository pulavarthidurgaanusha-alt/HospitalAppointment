using HospitalAppointment.Aspects;
using HospitalAppointment.Exceptions;
using HospitalAppointment.Models;
using HospitalAppointment.Services;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HospitalAppointment.Controllers
{
    [ApiController]
    [ExceptionHandler]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorsController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllDoctors()
        {
            var doctors = _service.GetAllDoctors();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            try
            {
                var doctor = _service.GetDoctorById(id);
                return Ok(doctor);
            }
            catch (DoctorNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateDoctor([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid doctor data.");

            try
            {
                _service.CreateDoctor(doctor);
                return StatusCode(201, "Doctor created successfully.");
            }
            catch (DoctorAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
            catch (DoctorCreationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDoctor(int id, [FromBody] Doctor doctor)
        {
            if (id != doctor.DoctorId)
                return BadRequest("Doctor ID mismatch.");

            if (!ModelState.IsValid)
                return BadRequest("Invalid doctor data.");

            try
            {
                _service.UpdateDoctor(doctor);
                return Ok("Doctor updated successfully.");
            }
            catch (DoctorNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DoctorUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            try
            {
                _service.DeleteDoctor(id);
                return Ok("Doctor deleted successfully.");
            }
            catch (DoctorNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DoctorDeletionException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search/location-specialty")]
        public IActionResult SearchByLocationAndSpecialty(string locationName, string specialty)
        {
            try
            {
                var result = _service.SearchDoctorsByLocationAndSpecialty(locationName, specialty);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500, new { error = "An unexpected error occurred." });
            }
        }

    }
}