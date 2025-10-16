using HospitalAppointment.Models;
using HospitalAppointment.Services;
using Microsoft.AspNetCore.Mvc;


namespace HospitalAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet]
        public IActionResult GetAllRatings()
        {
            var ratings = _ratingService.GetAllRatings();
            return Ok(ratings);
        }

        [HttpGet("{id}")]
        public IActionResult GetRatingById(int id)
        {
            var rating = _ratingService.GetRatingById(id);
            if (rating == null) return NotFound();
            return Ok(rating);
        }

        [HttpGet("highest-ratings")]
        public IActionResult GetHighestRatings()
        {
            var ratings = _ratingService.GetHighestRatings();
            return Ok(ratings);
        }

        [HttpPost]
        public IActionResult AddRating([FromBody] Rating rating)
        {
            try
            {
                var id = _ratingService.AddRating(rating);
                return CreatedAtAction(nameof(GetRatingById), new { id }, rating);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRating(int id, [FromBody] Rating rating)
        {
            if (id != rating.RatingId) return BadRequest();

            try
            {
                var updated = _ratingService.UpdateRating(rating);
                if (!updated) return NotFound();
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRating(int id)
        {
            var deleted = _ratingService.DeleteRating(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}