using System;

namespace HospitalAppointment.Exceptions
{
    public class AvailabilityConflictException : ApplicationException
    {
        public AvailabilityConflictException(DateTime date, TimeSpan startTime)
            : base($"Availability conflict detected on {date:yyyy-MM-dd} at {startTime}.") { }
    }
}
