using Microsoft.AspNetCore.Mvc;
using HospitalAppointment.Models;
using HospitalAppointment.Service;
using HospitalAppointment.Aspects;

namespace HospitalAppointment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ExceptionHandler] // Custom global exception handler
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public IActionResult GetAllLocations()
        {
            var locations = _locationService.GetAllLocations();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public IActionResult GetLocationById(int id)
        {
            var location = _locationService.GetLocationById(id);
            return Ok(location);
        }

        [HttpGet("city/{city}")]
        public IActionResult GetDoctorsByCity(string city)
        {
            var doctors = _locationService.GetDoctorsByCity(city);
            return Ok(doctors);
        }

        [HttpPost]
        public IActionResult CreateLocation([FromBody] Location location)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid location data.");

            if (!_locationService.DoctorExists(location.DoctorId))
                return BadRequest($"Doctor with ID {location.DoctorId} does not exist.");

            _locationService.AddLocation(location);
            return StatusCode(201, "Location created successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLocation(int id, [FromBody] Location location)
        {
            if (id != location.LocationId)
                return BadRequest("Location ID mismatch.");

            _locationService.UpdateLocation(location);
            return Ok("Location updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLocation(int id)
        {
            _locationService.DeleteLocation(id);
            return Ok("Location deleted successfully.");
        }
    }
}