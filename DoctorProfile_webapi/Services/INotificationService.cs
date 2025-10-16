using HospitalAppointment.Models;

namespace HospitalAppointment.Services
{
    public interface INotificationService
    {
        IEnumerable<Notification> GetUserNotifications(int userId);
        void MarkAsRead(int notificationId);

        void CreateNotificationOnAppointmentBooked(int appointmentId);
        void CreateNotificationOnAppointmentCancelledByDoctor(int appointmentId);
        void CreateNotificationOnAppointmentCancelledByPatient(int appointmentId);
        public void AddNotification(Notification notification);
        Notification GetNotificationById(int notificationId);

    }
}
