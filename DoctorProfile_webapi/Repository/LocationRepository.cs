using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly Appointment_BookingContext _context;

        public LocationRepository(Appointment_BookingContext context)
        {
            _context = context;
        }

        public IEnumerable<Location> GetAllLocations() =>
            _context.Location.ToList();

        public Location GetLocationById(int id) =>
            _context.Location.FirstOrDefault(l => l.LocationId == id);

        public IEnumerable<Location> GetDoctorsByCity(string city)
        {
            return _context.Location
                .Where(l => !string.IsNullOrEmpty(l.City) &&
                            l.City.ToLower().Contains(city.ToLower()))
                .ToList();
        }

        public void AddLocation(Location location)
        {
            _context.Location.Add(location);
            _context.SaveChanges();
        }

        public void UpdateLocation(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteLocation(int id)
        {
            var location = _context.Location.Find(id);
            if (location != null)
            {
                _context.Location.Remove(location);
                _context.SaveChanges();
            }
        }

        public bool LocationExists(int id) =>
            _context.Location.Any(l => l.LocationId == id);

        // ✅ New method to check if a doctor exists
        public bool DoctorExists(int doctorId) =>
            _context.Doctors.Any(d => d.DoctorId == doctorId);
    }
}