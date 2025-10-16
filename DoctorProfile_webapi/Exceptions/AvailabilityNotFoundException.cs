using System;

namespace HospitalAppointment.Exceptions
{
    public class AvailabilityNotFoundException : ApplicationException
    {
        public AvailabilityNotFoundException(int id)
            : base($"Availability with ID {id} was not found.") { }
    }
}
