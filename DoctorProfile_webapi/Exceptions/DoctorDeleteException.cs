using System;

namespace HospitalAppointment.Exceptions
{
    public class DoctorDeletionException : ApplicationException
    {
        public DoctorDeletionException(int id)
            : base($"Failed to delete doctor with ID {id}.") { }
    }
}