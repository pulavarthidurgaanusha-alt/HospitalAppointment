namespace HospitalAppointment.Exceptions
{
    public class AvailabilityNullException : ArgumentNullException
    {
        public AvailabilityNullException(string paramName)
            : base(paramName, $"Availability cannot be null. Parameter: {paramName}")
        {
        }
    }
}
