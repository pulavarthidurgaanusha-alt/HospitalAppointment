using System;

namespace HospitalAppointment.Exceptions
{
    public class DoctorAvailabilityNotFoundException : ApplicationException
    {
        public DoctorAvailabilityNotFoundException(int doctorId)
            : base($"No availability found for doctor ID: {doctorId}.") { }
    }
}
