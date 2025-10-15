using System;

namespace HospitalAppointment.Exceptions
{
    public class LocationNotFoundException : Exception
    {
        public LocationNotFoundException(int locationId)
            : base($"Location with ID {locationId} not found.") { }
    }
}