using System;

namespace HospitalAppointment.Exceptions
{
    public class DoctorCreationException : ApplicationException
    {
        public DoctorCreationException(string message)
            : base($"Doctor creation failed: {message}") { }
    }
}
