namespace HospitalAppointment.Exceptions
{
   
    
        public class SlotUnavailableException : Exception
        {
            public SlotUnavailableException() : base("Selected slot not available, please choose another time.") { }

            public SlotUnavailableException(string message) : base(message) { }

            public SlotUnavailableException(string message, Exception innerException) : base(message, innerException) { }
        }
    }

