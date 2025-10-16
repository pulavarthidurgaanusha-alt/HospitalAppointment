namespace HospitalAppointment.Exceptions
{
    public class InvalidAvailabilityTimeException:ApplicationException
    {
        public InvalidAvailabilityTimeException()
            : base("End time must be greater than start time for availability.") { }
    }
}
