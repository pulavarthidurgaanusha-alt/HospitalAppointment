using System;

namespace HospitalAppointment.Exceptions
{
    public class DoctorAlreadyExistsException : ApplicationException
    {
        public DoctorAlreadyExistsException() { }
        public DoctorAlreadyExistsException(string name) : base($"Doctor Name '{name}' Already Exists") { } 
         
    }
}
