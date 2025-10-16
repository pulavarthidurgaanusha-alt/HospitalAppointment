namespace HospitalAppointment.Exceptions
{
    public class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException(string message = "Session expired. Please log in again.")
            : base(message)
        {
        }
    }
}
