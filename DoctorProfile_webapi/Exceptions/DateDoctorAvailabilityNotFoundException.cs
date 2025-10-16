using System;

namespace HospitalAppointment.Exceptions
{
    public class DateDoctorAvailabilityNotFoundException : ApplicationException
    {
        public DateDoctorAvailabilityNotFoundException(DateTime date, int doctorId)
            : base($"No availability found for Doctor ID {doctorId} on {date:yyyy-MM-dd}.") { }
    }
}
