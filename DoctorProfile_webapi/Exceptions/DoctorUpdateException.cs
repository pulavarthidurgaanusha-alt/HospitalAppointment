using System;

namespace HospitalAppointment.Exceptions
{
    public class DoctorUpdateException : ApplicationException
    {
        public DoctorUpdateException(int id)
            : base($"Failed to update doctor with ID {id}.") { }
    }
}