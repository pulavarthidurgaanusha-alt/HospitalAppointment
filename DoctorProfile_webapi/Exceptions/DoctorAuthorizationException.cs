namespace HospitalAppointment.Exceptions
{
    public class DoctorAuthorizationException : ApplicationException
    {
        public DoctorAuthorizationException() { }
        public DoctorAuthorizationException(string message) : base(message) { }
    }
}
