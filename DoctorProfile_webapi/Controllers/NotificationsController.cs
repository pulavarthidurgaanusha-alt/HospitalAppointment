//using 
    
    
    
    
    
    
    
//    .Services;
//using Microsoft.AspNetCore.Mvc;

//namespace HospitalAppointment.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class NotificationController : ControllerBase
//    {
//        private readonly INotificationService _service;

//        public NotificationController(INotificationService service)
//        {
//            _service = service;
//        }

//        [HttpGet("{userId}")]
//        public IActionResult GetNotifications(int userId)
//        {
//            var notifications = _service.GetUserNotifications(userId);
//            return Ok(notifications);
//        }

//        [HttpPost("booked")]
//        public IActionResult CreateNotificationOnAppointmentBooked([FromQuery] int appointmentId)
//        {
//            _service.CreateNotificationOnAppointmentBooked(appointmentId);
//            return Ok("Notification for appointment booking created.");
//        }

//        [HttpPost("cancelled-by-doctor")]
//        public IActionResult CreateNotificationOnAppointmentCancelledByDoctor([FromQuery] int appointmentId)
//        {
//            _service.CreateNotificationOnAppointmentCancelledByDoctor(appointmentId);
//            return Ok("Notification for cancellation by doctor created.");
//        }

//        [HttpPost("cancelled-by-patient")]
//        public IActionResult CreateNotificationOnAppointmentCancelledByPatient([FromQuery] int appointmentId)
//        {
//            _service.CreateNotificationOnAppointmentCancelledByPatient(appointmentId);
//            return Ok("Notification for cancellation by patient created.");
//        }

//        [HttpPut("read/{id}")]
//        public IActionResult MarkAsRead(int id)
//        {
//            _service.MarkAsRead(id);
//            return Ok("Notification status updated to read.");
//        }
//    }
//}
