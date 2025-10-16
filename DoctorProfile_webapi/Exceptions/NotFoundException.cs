using System;


namespace HospitalAppointment.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException() { }
        public NotFoundException(string message) : base(message) { }
    }
}
