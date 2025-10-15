using HospitalAppointment.Models;
using System.Collections.Generic;

namespace HospitalAppointment.Repository
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAllLocations();
        Location GetLocationById(int id);
        IEnumerable<Location> GetDoctorsByCity(string city);
        void AddLocation(Location location);
        void UpdateLocation(Location location);
        void DeleteLocation(int id);
        bool LocationExists(int id);

        // ✅ New method
        bool DoctorExists(int doctorId);
    }
}