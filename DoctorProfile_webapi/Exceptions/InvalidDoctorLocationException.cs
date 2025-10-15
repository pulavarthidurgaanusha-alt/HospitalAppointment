using System;

namespace HospitalAppointment.Exceptions
{
    public class InvalidDoctorLocationException : ApplicationException
    {
        public InvalidDoctorLocationException(string location)
            : base($" '{location}' .") { }   ///is invalid or not supported.
    }
}
