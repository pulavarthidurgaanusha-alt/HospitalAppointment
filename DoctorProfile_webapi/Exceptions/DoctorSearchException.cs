using System;

namespace HospitalAppointment.Exceptions
{
    public class DoctorSearchException : ApplicationException
    {
        public DoctorSearchException(string criteria)
            : base($"Error occurred while searching for doctors by '{criteria}'.") { }
    }
}
