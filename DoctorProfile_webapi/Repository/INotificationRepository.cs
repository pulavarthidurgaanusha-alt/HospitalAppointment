using HospitalAppointment.Models;

namespace HospitalAppointment.Repository
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> GetUserNotifications(int userId);
        void MarkAsRead(int notificationId);

        void CreateNotificationOnAppointmentBooked(int appointmentId);
        void CreateNotificationOnAppointmentCancelledByDoctor(int appointmentId);
        void CreateNotificationOnAppointmentCancelledByPatient(int appointmentId);
        public void AddNotification(Notification notification);
        Notification GetNotificationById(int notificationId);
        
        void UpdateNotification(object notification);
        IEnumerable<Notification> GetNotificationsByUserId(int userId);
    }
}

