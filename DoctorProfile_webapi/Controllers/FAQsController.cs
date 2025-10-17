using HospitalAppointment.Models;
using HospitalAppointment.Services;
using Microsoft.AspNetCore.Mvc;
//using webapi.IServices;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQsController : ControllerBase
    {
        private readonly IFAQService _faqService;

        public FAQsController(IFAQService faqService)
        {
            _faqService = faqService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FAQ>> GetFAQs()
        {
            var faqs = _faqService.GetAllFAQs();
            return Ok(faqs);
        }

        [HttpGet("{id}")]
        public ActionResult<FAQ> GetFAQ(int id)
        {
            var faq = _faqService.GetFAQById(id);
            if (faq == null) return NotFound();
            return Ok(faq);
        }

        [HttpPost]
        public IActionResult PostFAQ([FromBody] FAQ faq)
        {
            _faqService.CreateFAQ(faq);
            return CreatedAtAction(nameof(GetFAQ), new { id = faq.FaqId }, faq);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFAQ(int id, [FromBody] FAQ faq)
        {
            if (id != faq.FaqId) return BadRequest("FAQ ID mismatch.");
            _faqService.UpdateFAQ(id, faq);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFAQ(int id)
        {
            _faqService.DeleteFAQ(id);
            return NoContent();
        }
    }
}