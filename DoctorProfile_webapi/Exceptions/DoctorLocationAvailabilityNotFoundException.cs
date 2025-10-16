using System;

namespace HospitalAppointment.Exceptions
{
    public class DoctorLocationAvailabilityNotFoundException : ApplicationException
    {
        public DoctorLocationAvailabilityNotFoundException(int doctorId, int locationId)
            : base($"No availability found for Doctor ID {doctorId} at Location ID {locationId}.") { }
    }
}
