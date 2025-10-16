namespace HospitalAppointment.Exceptions
{
    public class DateDoctorLocationAvailabilityNotFoundException : ApplicationException
    {
        public DateDoctorLocationAvailabilityNotFoundException(DateTime date, int doctorId, int locationId)
            : base($"No availability found for Doctor ID {doctorId} at Location ID {locationId} on {date:yyyy-MM-dd}.") { }
    }
}
