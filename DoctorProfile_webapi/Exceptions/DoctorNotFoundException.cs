using System;

namespace HospitalAppointment.Exceptions
{
    public class DoctorNotFoundException : ApplicationException
    {
        public DoctorNotFoundException(int id)
            : base($"Doctor with ID {id} was not found.") { }
    }
}