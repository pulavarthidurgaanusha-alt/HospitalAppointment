namespace HospitalAppointment.Exceptions
{
    public class ProfileNotFoundException: Exception
    {
        public ProfileNotFoundException(string message = "Unable to load profile information. Please try again later.")
            : base(message)
        {
        }

    }
}
