//using HospitalAppointment.Data;
using HospitalAppointment.Exceptions;
using HospitalAppointment.Models;
using HospitalAppointment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAppointment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvailabilityController : ControllerBase
    {
        private readonly IAvailabilityService _service;

        public AvailabilityController(IAvailabilityService service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult Add([FromBody] Availability availability)
        {
            _service.Add(availability);
            return CreatedAtAction(nameof(GetById), new { id = availability.AvailabilityId }, availability);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_service.GetById(id));

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Availability availability)
        {
            availability.AvailabilityId = id;
            _service.Update(availability);
            return Ok("Availability updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Availability deleted successfully.");
        }
        [HttpGet("search/doctor_id")]
        public IActionResult SearchByDoctorId([FromQuery] int doctorId)
        {
            try { return Ok(_service.SearchByDoctorId(doctorId)); }
            catch (DoctorAvailabilityNotFoundException ex) { return NotFound(new { message = ex.Message }); }
        }

        [HttpGet("search/location_id")]
        public IActionResult SearchByLocationId([FromQuery] int locationId)
        {
            try { return Ok(_service.SearchByLocationId(locationId)); }
            catch (LocationNotFoundException ex) { return NotFound(new { message = ex.Message }); }
        }

        
        [HttpGet("search/locationid-doctorid")]
        public IActionResult SearchByLocationAndDoctorId([FromQuery] int locationId, [FromQuery] int doctorId)
        {
            try
            {
                var results = _service.SearchByLocationAndDoctorId(locationId, doctorId);
                return Ok(results);
            }
            catch (DoctorLocationAvailabilityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("search/date-doctorid")]
        public IActionResult SearchByDateAndDoctorId([FromQuery] DateTime date, [FromQuery] int doctorId)
        {
            try
            {
                var results = _service.SearchByDateAndDoctorId(date, doctorId);
                return Ok(results);
            }
            catch (DateDoctorAvailabilityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("search/date-doctorid-locationid")]
        public IActionResult SearchByDateDoctorLocation([FromQuery] DateTime date, [FromQuery] int doctorId, [FromQuery] int locationId)
        {
            try
            {
                var results = _service.SearchByDateDoctorLocation(date, doctorId, locationId);
                return Ok(results);
            }
            catch (DateDoctorLocationAvailabilityNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

    }
}
