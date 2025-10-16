namespace HospitalMedicalHistory.Exceptions
{
    public class MedicalHistoryDeletionException : ApplicationException
    {
        public MedicalHistoryDeletionException() { }
        public MedicalHistoryDeletionException(string message) : base(message) { }
    }

}
