namespace HospitalAppointment.Exceptions
{
   
        public class AppointmentNotFoundException : Exception   //polymorphism
        {
            public AppointmentNotFoundException() : base("Appointment not found.") { }

            public AppointmentNotFoundException(string message) : base(message) { }
        }
    }

