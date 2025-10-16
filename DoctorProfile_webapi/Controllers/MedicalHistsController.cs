using HospitalAppointment.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HospitalAppointment.Services;
using HospitalAppointment.Models;

namespace HospitalAppointment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicalHistController : ControllerBase
    {
        private readonly IMedicalHistService _service;
        private readonly Appointment_BookingContext _context;

        public MedicalHistController(IMedicalHistService service, Appointment_BookingContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
       // [Authorize(Roles = "Doctor")]
        public IActionResult GetAll()
        {
            var histories = _service.GetAllMedicalHistories();
            return Ok(histories);
        }

        [HttpGet("{id}")]
       // [Authorize(Roles = "Doctor")]
        public IActionResult GetById(int id)
        {
            var history = _service.GetMedicalHistoryById(id);
            if (history == null)
                throw new NotFoundException("Medical history not found.");
            return Ok(history);
        }

        [HttpGet("patient/{patientId}")]
        //[Authorize(Roles = "Doctor")]
        public IActionResult GetByPatientId(int patientId)
        {
            var histories = _service.GetMedicalHistoriesByPatientId(patientId);
            return Ok(histories);
        }
        //Mandatory to use jwt token then only it will get executed.
        [HttpGet("my-history")]
        //[Authorize(Roles = "Patient")]
        public IActionResult GetMyHistory()
        {
            var userIdClaim = User.FindFirstValue("UserId");
            if (string.IsNullOrEmpty(userIdClaim))
                throw new ValidationException("User ID claim is missing.");

            if (!int.TryParse(userIdClaim, out int userId))
                throw new ValidationException("Invalid User ID.");

            var patientId = GetPatientIdByUserId(userId);
            if (patientId == 0)
                throw new NotFoundException("Patient not found.");

            var histories = _service.GetMedicalHistoriesByPatientId(patientId);
            return Ok(histories);
        }

        [HttpGet("search")]
        //[Authorize(Roles = "Doctor")]
        public IActionResult Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ValidationException("Search keyword cannot be empty.");

            var results = _service.SearchMedicalHistories(keyword);
            return Ok(results);
        }
        /* [HttpPost]
         [Authorize(Roles = "Doctor")]
         public IActionResult Add([FromBody] MedicalHist history)
         {
             if (history.PatientId <= 0 || history.DoctorId <= 0)
                 throw new ValidationException("Patient and Doctor IDs are required.");

             try
             {
                 var result = _repository.AddMedicalHistory(history);
                 if (result <= 0)
                     throw new MedicalHistoryCreationException("Failed to add medical history.");

                 return Ok(history);
             }
             catch (Exception ex)
             {
                 return StatusCode(500, $"Internal server error: {ex.Message}");
             }
         }*/
        [HttpPost]
        //[Authorize(Roles = "Doctor")]
        public IActionResult Add([FromBody] MedicalHistCreateDto dto)
        {
            if (dto.PatientId <= 0 || dto.DoctorId <= 0)
                throw new ValidationException("Patient and Doctor IDs are required.");

            var history = new MedicalHist
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                Diagnosis = dto.Diagnosis,
                Treatment = dto.Treatment,
                DateOfVisit = dto.DateOfVisit
            };

            var result = _service.AddMedicalHistory(history);
            if (result <= 0)
                throw new MedicalHistoryCreationException("Failed to add medical history.");

            return Ok(history);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MedicalHistUpdateDto dto)
        {
            var existing = _service.GetMedicalHistoryById(id);
            if (existing == null)
                throw new NotFoundException("Medical history not found.");

            if (existing.DoctorId != dto.DoctorId)
                throw new DoctorAuthorizationException("Doctor not authorized to update this record.");

            existing.PatientId = dto.PatientId;
            existing.DoctorId = dto.DoctorId;
            existing.Diagnosis = dto.Diagnosis;
            existing.Treatment = dto.Treatment;
            existing.DateOfVisit = dto.DateOfVisit;

            var result = _service.UpdateMedicalHistory(id, existing);
            if (result <= 0)
                throw new MedicalHistoryUpdateException("Failed to update medical history.");

            return NoContent();
        }


        /*
        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public IActionResult Add([FromBody] MedicalHist history)
        {
            if (history.PatientId <= 0 || history.DoctorId <= 0)
                throw new ValidationException("Patient and Doctor IDs are required.");

            var result = _repository.AddMedicalHistory(history);
            if (result <= 0)
                throw new MedicalHistoryCreationException("Failed to add medical history.");

            return Ok(history);
        }*/

        /*  [HttpPut("{id}")]
          //[Authorize(Roles = "Doctor")]
          public IActionResult Update(int id, [FromBody] MedicalHist history)
          {
              var existing = _service.GetMedicalHistoryById(id);
              if (existing == null)
                  throw new NotFoundException("Medical history not found.");

              if (existing.DoctorId != history.DoctorId)
                  throw new DoctorAuthorizationException("Doctor not authorized to update this record.");

              var result = _service.UpdateMedicalHistory(id, history);
              if (result <= 0)
                  throw new MedicalHistoryUpdateException("Failed to update medical history.");

              return NoContent();
          }*/

        // Optional Admin delete endpoints (uncomment if needed)

        //[HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        //public IActionResult Delete(int id)
        //{
        //    var existing = _repository.GetMedicalHistoryById(id);
        //    if (existing == null)
        //        throw new NotFoundException("Medical history not found.");

        //    var result = _repository.DeleteMedicalHistoryById(id);
        //    if (result <= 0)
        //        throw new MedicalHistoryDeletionException("Failed to delete medical history.");

        //    return NoContent();
        //}

        //[HttpDelete("all")]
        //[Authorize(Roles = "Admin")]
        //public IActionResult DeleteAll()
        //{
        //    var result = _repository.DeleteAllMedicalHistories();
        //    if (result <= 0)
        //        throw new MedicalHistoryDeletionException("Failed to delete all medical histories.");

        //    return NoContent();
        //}

        private int GetPatientIdByUserId(int userId)
        {
            var patient = _context.Patients.FirstOrDefault(p => p.UserId == userId);
            return patient?.PatientId ?? 0;
        }
    }
}
