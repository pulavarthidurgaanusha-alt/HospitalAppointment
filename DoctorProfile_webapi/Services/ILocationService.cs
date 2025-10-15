using System.Collections.Generic;
using HospitalAppointment.Models;

namespace HospitalAppointment.Service
{
    public interface ILocationService
    {
        IEnumerable<Location> GetAllLocations();
        Location GetLocationById(int id);
        IEnumerable<Location> GetDoctorsByCity(string city);
        void AddLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(int id);
        bool LocationExists(int id);

        // ✅ New method to check if a doctor exists
        bool DoctorExists(int doctorId);
    }
}