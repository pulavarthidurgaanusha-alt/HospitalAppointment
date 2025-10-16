namespace HospitalAppointment.Exceptions
{
    public class ValidationException: Exception
    {
        public ValidationException(string message = "Field validation failed.")
            : base(message)
        {
        }
    }
}
