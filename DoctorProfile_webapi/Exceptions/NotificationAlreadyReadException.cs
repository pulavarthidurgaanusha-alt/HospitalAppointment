namespace HospitalAppointment.Exceptions
{
    public class NotificationAlreadyReadException : Exception
    {
        public NotificationAlreadyReadException(string message) : base(message) { }
    }
}

