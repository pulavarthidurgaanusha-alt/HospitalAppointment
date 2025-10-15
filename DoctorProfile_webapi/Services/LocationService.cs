using System.Collections.Generic;
using HospitalAppointment.Models;
using HospitalAppointment.Repository;

namespace HospitalAppointment.Service
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public IEnumerable<Location> GetAllLocations() => _locationRepository.GetAllLocations();

        public Location GetLocationById(int id) => _locationRepository.GetLocationById(id);

        public IEnumerable<Location> GetDoctorsByCity(string city) => _locationRepository.GetDoctorsByCity(city);

        public void AddLocation(Location location) => _locationRepository.AddLocation(location);

        public void UpdateLocation(Location location) => _locationRepository.UpdateLocation(location);

        public void DeleteLocation(int id) => _locationRepository.DeleteLocation(id);

        public bool LocationExists(int id) => _locationRepository.LocationExists(id);

        // ✅ Implementation of DoctorExists
        public bool DoctorExists(int doctorId) => _locationRepository.DoctorExists(doctorId);
    }
}