using System;

namespace HospitalAppointment.Exceptions
{
    public class DateAvailabilityNotFoundException : ApplicationException
    {
        public DateAvailabilityNotFoundException(DateTime date)
            : base($"No availability found for date: {date:yyyy-MM-dd}.") { }
    }
}
