namespace HospitalAppointment.Exceptions
{
    public class InvalidAppointmentStatusException : Exception
    {
        public InvalidAppointmentStatusException() : base("Appointment status change is not allowed.") { }

        public InvalidAppointmentStatusException(string message) : base(message) { }
    }

}

