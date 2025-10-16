namespace HospitalAppointment.Exceptions
{
    public class DoctorAndLocationNotFoundException : ApplicationException
    {
        public DoctorAndLocationNotFoundException(int doctorId, int locationId)
            : base($"Doctor ID {doctorId} and Location ID {locationId} do not exist.") { }
    }
}
