namespace HospitalAppointment.Exceptions
{
    public class MedicalHistoryCreationException : ApplicationException
    {
        public MedicalHistoryCreationException() { }
        public MedicalHistoryCreationException(string message) : base(message) { }

    }
}
