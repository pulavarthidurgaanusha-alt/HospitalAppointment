using HospitalAppointment.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
             public async Task<List<object>> GetDoctorsBySpecialityRatingAsync(string speciality)
        {
            var connection = _context.Database.GetDbConnection();
            await connection.OpenAsync();

            using var command = connection.CreateCommand();
            command.CommandText = "GetDoctorsBySpecialityRating";
            command.CommandType = CommandType.StoredProcedure;

            var param = new SqlParameter("@Specialization", speciality);
            command.Parameters.Add(param);

            var result = new List<object>();

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var doctorName = reader["DoctorName"].ToString();
                var specialization = reader["Specialization"].ToString();
                var averageRating = Convert.ToDouble(reader["AverageRating"]);

                result.Add(new
                {
                    DoctorName = doctorName,
                    Specialization = specialization,
                    AverageRating = averageRating
                });
            }

            return result;
        }
    }
    }
