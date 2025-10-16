//using HospitalAppointment.Data;
using HospitalAppointment.Exceptions;
using HospitalAppointment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAppointment.Controllers
{
 
        [Route("api/[controller]")]
        [ApiController]
        public class PatientsController : ControllerBase
        {
            private readonly Appointment_BookingContext _context;

            public PatientsController(Appointment_BookingContext context)
            {
                _context = context;
            }

            // GET: api/Patients
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
            {
                return await _context.Patients
                    .Include(p => p.User)
                    .ToListAsync();
            }

            // GET: api/Patients/{id}
            [HttpGet("{id}")]
            public async Task<IActionResult> GetPatientById(int id)
            {
                var patient = await _context.Patients
                    .Include(p => p.User)
                    .FirstOrDefaultAsync(p => p.PatientId == id);

                if (patient == null)
                {
                    throw new ProfileNotFoundException($"Patient with ID {id} not found.");
                }

                return Ok(patient);
            }

            // GET: api/Patients/profile/{id}
            [HttpGet("profile/{id}")]
            public async Task<IActionResult> GetPatientProfile(int id)
            {
                var patient = await _context.Patients
                    .Include(p => p.User)
                    .FirstOrDefaultAsync(p => p.PatientId == id);

                if (patient == null)
                {
                    throw new ProfileNotFoundException($"Patient with ID {id} not found.");
                }

                var profile = new
                {
                    Name = string.IsNullOrWhiteSpace(patient.Name) ? "Not provided" : patient.Name,
                    Dob = patient.Dob == default ? "Not provided" : patient.Dob.ToString("yyyy-MM-dd"),
                    Gender = patient.Gender.ToString(),
                    Phone = string.IsNullOrWhiteSpace(patient.Phone) ? "Not provided" : patient.Phone,
                    Address = string.IsNullOrWhiteSpace(patient.Address) ? "Not provided" : patient.Address,
                    Email = string.IsNullOrWhiteSpace(patient.User?.Email) ? "Not provided" : patient.User.Email,
                    Allergies = "No medical info recorded",
                    ChronicConditions = "No medical info recorded",
                    CurrentMedications = "No medical info recorded"
                };

                return Ok(profile);
            }

            // PUT: api/Patients/{id}
            [HttpPut("{id}")]
            public async Task<IActionResult> PutPatient(int id, Patient patient)
            {
                if (id != patient.PatientId)
                {
                    throw new ValidationException("Patient ID mismatch.");
                }

                if (!TryValidateModel(patient))
                {
                    throw new ValidationException("Invalid patient data.");
                }

                _context.Entry(patient).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                    return Ok(new { message = "Changes updated successfully." });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientExists(id))
                    {
                        throw new ProfileNotFoundException($"Patient with ID {id} not found.");
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            // POST: api/Patients
            [HttpPost]
            public async Task<ActionResult<Patient>> PostPatient(Patient patient)
            {
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPatientById), new { id = patient.PatientId }, patient);
            }

            // DELETE: api/Patients/{id}
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeletePatient(int id)
            {
                var patient = await _context.Patients.FindAsync(id);
                if (patient == null)
                {
                    throw new ProfileNotFoundException($"Patient with ID {id} not found.");
                }

                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool PatientExists(int id)
            {
                return _context.Patients.Any(e => e.PatientId == id);
            }

            // Optional: Exception Testing Endpoints
            /*
            [HttpGet("test-profile-not-found")]
            public IActionResult TestProfileNotFound()
            {
                throw new ProfileNotFoundException();
            }

            [HttpPost("test-validation")]
            public IActionResult TestValidation([FromBody] string email)
            {
                if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                    throw new ValidationException("Invalid email format.");

                return Ok("Valid email");
            }

            [HttpGet("test-missing-data")]
            public IActionResult TestMissingData()
            {
                throw new MissingDataException("Date of birth or gender is missing.");
            }

            [HttpGet("test-navigation")]
            public IActionResult TestNavigation()
            {
                throw new NavigationException("Unable to navigate to the selected page.");
            }
            */
        }
    }

