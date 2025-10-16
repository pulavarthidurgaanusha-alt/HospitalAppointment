namespace HospitalAppointment.Exceptions
{
    public class NavigationException : Exception
    {
        public NavigationException(string message = "Unable to navigate to the selected page. Please contact support.")
           : base(message)
        {
        }
    }
}
