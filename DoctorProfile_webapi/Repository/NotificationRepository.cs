using HospitalAppointment.Models;

namespace HospitalAppointment.Repository
{
    public class NotificationRepository : INotificationRepository
    {

        private readonly Appointment_BookingContext _context;

        public NotificationRepository(Appointment_BookingContext context)
        {
            _context = context;
        }

        public void AddNotification(Notification notification)
        {
            _context.Notification.Add(notification);
            _context.SaveChanges();
        }

        public IEnumerable<Notification> GetNotificationsByUserId(int userId)
        {
            return _context.Notification
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedAt)
                .ToList();
        }

        public Notification GetNotificationById(int id)
        {
            return _context.Notification.FirstOrDefault(n => n.NotificationId == id);
        }

        public void UpdateNotification(Notification notification)
        {
            _context.Notification.Update(notification);
            _context.SaveChanges();
        }

        IEnumerable<Notification> INotificationRepository.GetUserNotifications(int userId)
        {
            throw new NotImplementedException();
        }

        void INotificationRepository.MarkAsRead(int notificationId)
        {
            throw new NotImplementedException();
        }

        void INotificationRepository.CreateNotificationOnAppointmentBooked(int appointmentId)
        {
            throw new NotImplementedException();
        }

        void INotificationRepository.CreateNotificationOnAppointmentCancelledByDoctor(int appointmentId)
        {
            throw new NotImplementedException();
        }

        void INotificationRepository.CreateNotificationOnAppointmentCancelledByPatient(int appointmentId)
        {
            throw new NotImplementedException();
        }

        Notification INotificationRepository.GetNotificationById(int notificationId)
        {
            throw new NotImplementedException();
        }

        void INotificationRepository.UpdateNotification(object notification)
        {
            throw new NotImplementedException();
        }


    }


    }
