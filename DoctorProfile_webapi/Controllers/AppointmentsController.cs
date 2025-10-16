//using HospitalAppointment.Aspects;
//using HospitalAppointment.Data;
//using HospitalAppointment.Exceptions;
//using HospitalAppointment.Models;
//using HospitalAppointment.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace HospitalAppointment.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    [ExceptionHandler]
//    public class AppointmentController : ControllerBase
//    {
//        private readonly IAppointmentService _service;
//        private readonly Appointment_ManagementContext _context;

//        public AppointmentController(HospitalAppointmentContext context, IAppointmentService service)
//        {
//            _context = context;
//            _service = service;
//        }

//        [HttpGet]
//        public IActionResult GetAppointments()
//        {
//            var appointments = _service.GetAppointments();
//            return Ok(appointments);
//        }

//        [HttpGet("{id}")]
//        public IActionResult GetAppointment(int id)
//        {
//            var appointment = _service.GetAppointmentById(id);
//            return Ok(appointment);
//        }

//        //[Authorize[Role="Doctor"]]

//        [HttpGet("doctor/{doctorId}")]
//        public IActionResult GetAppointmentsByDoctorId(int doctorId)
//        {
//            var appointments = _service.GetAppointmentsByDoctorId(doctorId);
//            return Ok(appointments);
//        }

//        //[Authorize[Role="Patient"]]

//        [HttpGet("patient/{patientId}")]
//        public IActionResult GetAppointmentsByPatientId(int patientId)
//        {
//            var appointments = _service.GetAppointmentsByPatientId(patientId);
//            return Ok(appointments);
//        }

//        //[Authorize[Role="Patient"]]
//        [HttpPost("book")]
//        public IActionResult BookAppointment([FromBody] Appointment appointment)
//        {
//            var result = _service.BookAppointment(appointment);
//            return Ok(new { Message = "Appointment booked successfully.", AppointmentId = result.AppointmentId });
//        }

//        [HttpPut("complete/{id}")]
//        public IActionResult ChangeStatusToCompleted(int id)
//        {
//            var updated = _service.ChangeStatusToCompleted(id);
//            return Ok("Appointment marked as completed.");
//        }

//        //[Authorize[Role="Doctor"]]
//        [HttpPut("cancel/doctor/{id}")]
//        public IActionResult CancelledByDoctor(int id)
//        {
//            var updated = _service.CancelledByDoctor(id);
//            return Ok("Appointment cancelled by doctor.");
//        }

//        //[Authorize[Role="Patient"]]
//        [HttpPut("cancel/patient/{id}")]
//        public IActionResult CancelledByPatient(int id)
//        {
//            var updated = _service.CancelledByPatient(id);
//            return Ok("Appointment cancelled by patient.");
//        }

//        //[Authorize[Role="Doctor"]]
//        [HttpGet("doctor/summary/{doctorId}")]
//        public IActionResult GetDoctorDailySummary(int doctorId)
//        {
//            var today = DateTime.Today;

//            //var upcomingAppointments = (from a in _context.Appointment
//            //                            where a.DoctorId == doctorId &&
//            //                                  a.AppointmentDate == today &&
//            //                                  a.Status == Appointment.AppointmentStatus.Booked
//            //                            join p in _context.Patient on a.PatientId equals p.PatientId
//            //                            join av in _context.Availability on a.AvailabilityId equals av.AvailabilityId
//            //                            join l in _context.Location on av.LocationId equals l.LocationId
//            //                            select new
//            //                            {
//            //                                a.AppointmentTime,
//            //                                PatientName = p.Name,
//            //                                Location = l.ClinicName
//            //                            }).ToList();

//            var totalAppointments = _context.Appointment
//                .Count(a => a.DoctorId == doctorId && a.AppointmentDate == today);

//            var completedAppointments = _context.Appointment
//                .Count(a => a.DoctorId == doctorId && a.AppointmentDate == today && a.Status == Appointment.AppointmentStatus.Completed);

//            var remainingAppointments = _context.Appointment
//                .Count(a => a.DoctorId == doctorId && a.AppointmentDate == today && a.Status == Appointment.AppointmentStatus.Booked);

//            return Ok(new
//            {
//                TotalAppointments = totalAppointments == 0 ? "No appointments for today." : totalAppointments.ToString(),
//                CompletedAppointments = completedAppointments,
//                RemainingAppointments = remainingAppointments,
//                //UpcomingAppointments = upcomingAppointments
//            });
//        }
//    }
//}



////using HospitalAppointment.Aspects;
////using HospitalAppointment.Data;
////using HospitalAppointment.Exceptions;
////using HospitalAppointment.Models;
////using HospitalAppointment.Services;
////using Microsoft.AspNetCore.Mvc;
////using Microsoft.EntityFrameworkCore;

////namespace HospitalAppointment.Controllers
////{
////    [Route("api/[controller]")]
////    [ApiController]
////    [ExceptionHandler]
////    public class AppointmentController : ControllerBase
////    {
////        private readonly IAppointmentService _service;
////        private readonly HospitalAppointmentContext _context;
////        public AppointmentController(HospitalAppointmentContext context, IAppointmentService service)
////        {

////            _context = context;
////            _service = service;

////        }

////        [HttpGet]
////        public IActionResult GetAppointments()
////        {
////            var appointments = _service.GetAppointments();
////            return Ok(appointments);
////        }

////        [HttpGet("{id}")]
////        public IActionResult GetAppointment(int id)
////        {
////            var appointment = _service.GetAppointmentById(id);
////            return Ok(appointment);
////        }

////        [HttpGet("doctor/{doctorId}")]
////        public IActionResult GetAppointmentsByDoctorId(int doctorId)
////        {
////            var appointments = _service.GetAppointmentsByDoctorId(doctorId);
////            return Ok(appointments);
////        }

////        [HttpGet("patient/{patientId}")]
////        public IActionResult GetAppointmentsByPatientId(int patientId)
////        {
////            var appointments = _service.GetAppointmentsByPatientId(patientId);
////            return Ok(appointments);
////        }

////        [HttpPost("book")]
////        public IActionResult BookAppointment([FromBody] Appointment appointment)
////        {
////            var result = _service.BookAppointment(appointment);
////            return Ok(new { Message = "Appointment booked successfully.", AppointmentId = result.AppointmentId });
////        }

////        [HttpPut("complete/{id}")]
////        public IActionResult ChangeStatusToCompleted(int id)
////        {
////            var updated = _service.ChangeStatusToCompleted(id);
////            return Ok("Appointment marked as completed.");
////        }

////        [HttpPut("cancel/doctor/{id}")]
////        public IActionResult CancelledByDoctor(int id)
////        {
////            var updated = _service.CancelledByDoctor(id);
////            return Ok("Appointment cancelled by doctor.");
////        }

////        [HttpPut("cancel/patient/{id}")]
////        public IActionResult CancelledByPatient(int id)
////        {
////            var updated = _service.CancelledByPatient(id);
////            return Ok("Appointment cancelled by patient.");
////        }

////        [HttpGet("doctor/summary/{doctorId}")]
////        public IActionResult GetDoctorDailySummary(int doctorId)
////        {
////            var today = DateTime.Today;

////            var upcomingAppointments = _context.Appointment
////                .Where(a => a.DoctorId == doctorId && a.AppointmentDate == today && a.Status == Appointment.AppointmentStatus.Booked)
////                .Join(_context.Patient,
////                      a => a.PatientId,
////                      p => p.PatientId,
////                      (a, p) => new
////                      {
////                          a.AppointmentTime,
////                          p.Name,
////                          Location = _context.Availability
////                              .Where(av => av.AvailabilityId == a.AvailabilityId)
////                              .Join(_context.Location,
////                                    av => av.LocationId,
////                                    l => l.LocationId,
////                                    (av, l) => l.ClinicName)
////                              .FirstOrDefault()
////                      })
////                .ToList();

////            var totalAppointments = _context.Appointment
////                .Count(a => a.DoctorId == doctorId && a.AppointmentDate == today);

////            var completedAppointments = _context.Appointment
////                .Count(a => a.DoctorId == doctorId && a.AppointmentDate == today && a.Status == Appointment.AppointmentStatus.Completed);

////            var remainingAppointments = _context.Appointment
////                .Count(a => a.DoctorId == doctorId && a.AppointmentDate == today && a.Status == Appointment.AppointmentStatus.Booked);

////            return Ok(new
////            {
////                TotalAppointments = totalAppointments == 0 ? "No appointments for today." : totalAppointments.ToString(),
////                CompletedAppointments = completedAppointments,
////                RemainingAppointments = remainingAppointments,
////                UpcomingAppointments = upcomingAppointments
////            });
////        }
////    }
////}

////using HospitalAppointment.Models;
////using HospitalAppointment.Services;
////using HospitalAppointment.Exceptions;
////using Microsoft.AspNetCore.Mvc;

////namespace HospitalAppointment.Controllers
////{
////    [Route("api/[controller]")]
////    [ApiController]
////    public class AppointmentController : ControllerBase
////    {
////        private readonly IAppointmentService _service;

////        public AppointmentController(IAppointmentService service)
////        {
////            _service = service;
////        }

////        [HttpGet]
////        public IActionResult GetAppointments()
////        {
////            try
////            {
////                var appointments = _service.GetAppointments();
////                return Ok(appointments);
////            }
////            catch (Exception ex)
////            {
////                return StatusCode(500, ex.Message);
////            }
////        }

////        [HttpGet("{id}")]
////        public IActionResult GetAppointment(int id)
////        {
////            try
////            {
////                var appointment = _service.GetAppointmentById(id);
////                return Ok(appointment);
////            }
////            catch (AppointmentNotFoundException ex)
////            {
////                return NotFound(ex.Message);
////            }
////            catch (Exception ex)
////            {
////                return StatusCode(500, ex.Message);
////            }
////        }

////        [HttpPost("book")]
////        public IActionResult BookAppointment([FromBody] Appointment appointment)
////        {
////            try
////            {
////                var result = _service.BookAppointment(appointment);
////                return Ok(new { Message = "Appointment booked successfully.", AppointmentId = result.AppointmentId });
////            }
////            catch (SlotUnavailableException ex)
////            {
////                return BadRequest(ex.Message);
////            }
////            catch (Exception ex)
////            {
////                return StatusCode(500, ex.Message);
////            }
////        }

////        [HttpPut("{id}")]
////        public IActionResult UpdateAppointment(int id, [FromBody] Appointment appointment)
////        {
////            try
////            {
////                if (id != appointment.AppointmentId)
////                    return BadRequest("Appointment ID mismatch.");

////                var updated = _service.UpdateAppointment(appointment);
////                return Ok("Appointment updated.");
////            }
////            catch (AppointmentNotFoundException ex)
////            {
////                return NotFound(ex.Message);
////            }
////            catch (Exception ex)
////            {
////                return StatusCode(500, ex.Message);
////            }
////        }

////        [HttpDelete("{id}")]
////        public IActionResult CancelAppointment(int id)
////        {
////            try
////            {
////                var cancelled = _service.CancelAppointment(id);
////                return Ok("Appointment cancelled.");
////            }
////            catch (AppointmentNotFoundException ex)
////            {
////                return NotFound(ex.Message);
////            }
////            catch (Exception ex)
////            {
////                return StatusCode(500, ex.Message);
////            }
////        }
////    }
////}


