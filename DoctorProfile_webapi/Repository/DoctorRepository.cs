using HospitalAppointment.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly Appointment_BookingContext _context;

        public DoctorRepository(Appointment_BookingContext context)
        {
            _context = context;
        }

        public void CreateDoctor(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public Doctor GetDoctorById(int id) =>
            _context.Doctors.FirstOrDefault(d => d.DoctorId == id);

        public IEnumerable<Doctor> GetAllDoctors() =>
            _context.Doctors.ToList();

        public void UpdateDoctor(Doctor doctor)
        {
            var existingDoctor = _context.Doctors.Find(doctor.DoctorId);
            if (existingDoctor == null)
                throw new DoctorNotFoundException(doctor.DoctorId);

            existingDoctor.Name = doctor.Name;
            existingDoctor.Phone = doctor.Phone;
            existingDoctor.Specialization = doctor.Specialization;
            existingDoctor.ExperienceYears = doctor.ExperienceYears;
            existingDoctor.Qualification = doctor.Qualification;
            existingDoctor.Gender = doctor.Gender;

            _context.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            var doctor = _context.Doctors.Find(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
        }

        public bool ExistsByName(string name) =>
            _context.Doctors.Any(d => d.Name.ToLower() == name.ToLower());

        public IEnumerable<object> SearchDoctorsByLocationAndSpecialty(string locationName, string specialty)
        {
            var normalizedSpecialty = specialty.Trim().ToLower();
            var normalizedLocation = locationName.Trim().ToLower();

            var doctors = _context.Doctors
                .Include(d => d.Locations)
                //.Include(d => d.Rating)
                .Where(d =>
                    d.Specialization.ToLower() == normalizedSpecialty &&
                    d.Locations.Any(l => l.City.ToLower() == normalizedLocation))
                .Select(d => new
                {
                    d.Name,
                    d.Gender,
                    d.Specialization,
                    d.Qualification,
                    //Rating = _context.Ratings
                    //    .Where(r => r.DoctorId == d.DoctorId)
                    //    .Select(r => (double?)r.Value)
                    //    .DefaultIfEmpty(0)
                    //    .Average()
                })
                .ToList<object>();

            return doctors;
        }
    }
    }
