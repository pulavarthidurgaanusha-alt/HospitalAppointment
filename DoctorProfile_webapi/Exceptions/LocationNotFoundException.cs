using System;

namespace HospitalAppointment.Exceptions
{
    public class LocationNotFoundException : Exception
    {
        public LocationNotFoundException(int locationId)
            : base($"Location with ID {locationId} not found.") { }
        public LocationNotFoundException(int locationId, string context)
            : base($"Location with ID {locationId} does not exist in context.") { }
    }
}