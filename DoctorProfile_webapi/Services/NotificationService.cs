using HospitalAppointment.Exceptions;
using HospitalAppointment.Models;
using HospitalAppointment.Repository;

namespace HospitalAppointment.Services
{
   
    
        public class NotificationService : INotificationService
        {
            private readonly INotificationRepository _repository;
            private readonly Appointment_BookingContext _context;

            public NotificationService(INotificationRepository repository, Appointment_BookingContext context)
            {
                _repository = repository;
                _context = context;
            }

            public void CreateNotificationOnAppointmentBooked(int appointmentId)
            {
                var appointment = _context.Appointment.Find(appointmentId)
                    ?? throw new NotificationCreationFailedException("Appointment not found.");

                var doctor = _context.Doctors.Find(appointment.DoctorId);
                var patient = _context.Patients.Find(appointment.PatientId);

                var message = $"Your appointment with Dr. {doctor.Name} on {appointment.AppointmentDate:MMMM dd, yyyy} at {appointment.AppointmentTime} has been successfully booked.";

                _repository.AddNotification(new Notification
                {
                    UserId = patient.UserId,
                    Message = message,
                    CreatedAt = DateTime.Now,
                    Read = false
                });
            }

            public void CreateNotificationOnAppointmentCancelledByDoctor(int appointmentId)
            {
                var appointment = _context.Appointment.Find(appointmentId)
                    ?? throw new NotificationCreationFailedException("Appointment not found.");

                var doctor = _context.Doctors.Find(appointment.DoctorId);
                var patient = _context.Patients.Find(appointment.PatientId);

                var message = $"Your appointment with Dr. {doctor.Name} on {appointment.AppointmentDate:MMMM dd, yyyy} at {appointment.AppointmentTime} has been cancelled by the doctor.";

                _repository.AddNotification(new Notification
                {
                    UserId = patient.UserId,
                    Message = message,
                    CreatedAt = DateTime.Now,
                    Read = false
                });
            }

            public void CreateNotificationOnAppointmentCancelledByPatient(int appointmentId)
            {
                var appointment = _context.Appointment.Find(appointmentId)
                    ?? throw new NotificationCreationFailedException("Appointment not found.");

                var doctor = _context.Doctors.Find(appointment.DoctorId);
                var patient = _context.Patients.Find(appointment.PatientId);

                var message = $"Patient {patient.Name} has cancelled the appointment scheduled on {appointment.AppointmentDate:MMMM dd, yyyy} at {appointment.AppointmentTime}.";

                _repository.AddNotification(new Notification
                {
                    UserId = doctor.UserId,
                    Message = message,
                    CreatedAt = DateTime.Now,
                    Read = false
                });
            }

            public IEnumerable<Notification> GetUserNotifications(int userId)
            {
                return _repository.GetNotificationsByUserId(userId);
            }

            public void MarkAsRead(int notificationId)
            {
            var notification = _repository.GetNotificationById(notificationId)
                    ??throw new NotificationNotFoundException($"Notification with ID {notificationId} not found.");

                if (notification.Read)
                    throw new NotificationAlreadyReadException($"Notification with ID {notificationId} is already marked as read.");

                notification.Read = true;
                _repository.UpdateNotification(notification);
            }

        void INotificationService.AddNotification(Notification notification)
        {
            throw new NotImplementedException();
        }

        Notification INotificationService.GetNotificationById(int notificationId)
        {
            throw new NotImplementedException();
        }
    }
    }

