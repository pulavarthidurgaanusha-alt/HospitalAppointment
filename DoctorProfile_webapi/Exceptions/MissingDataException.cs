namespace HospitalAppointment.Exceptions
{
    public class MissingDataException : Exception
    {
        public MissingDataException(string message = "Some profile details could not be displayed due to missing data.")
            : base(message)
        {
        }
    }
}
