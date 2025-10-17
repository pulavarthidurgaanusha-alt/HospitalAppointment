using HospitalAppointment.Exceptions;
using HospitalAppointment.Models;
using HospitalAppointment.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace HospitalAppointment.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repo;

        public DoctorService(IDoctorRepository repo)
        {
            _repo = repo;
        }

        public void CreateDoctor(Doctor doctor)
        {
            if (_repo.ExistsByName(doctor.Name))
                throw new DoctorAlreadyExistsException(doctor.Name);

            try
            {
                _repo.CreateDoctor(doctor);
            }
            catch (Exception ex)
            {
                throw new DoctorCreationException(ex.Message);
            }
        }

        public Doctor GetDoctorById(int id)
        {
            var doctor = _repo.GetDoctorById(id);
            if (doctor == null)
                throw new DoctorNotFoundException(id);

            return doctor;
        }

        public IEnumerable<Doctor> GetAllDoctors() => _repo.GetAllDoctors();

        public void UpdateDoctor(Doctor doctor)
        {
            if (_repo.GetDoctorById(doctor.DoctorId) == null)
                throw new DoctorNotFoundException(doctor.DoctorId);

            try
            {
                _repo.UpdateDoctor(doctor);
            }
            catch (Exception)
            {
                throw new DoctorUpdateException(doctor.DoctorId);
            }
        }

        public void DeleteDoctor(int id)
        {
            if (_repo.GetDoctorById(id) == null)
                throw new DoctorNotFoundException(id);

            try
            {
                _repo.DeleteDoctor(id);
            }
            catch (Exception)
            {
                throw new DoctorDeletionException(id);
            }
        }

        public IEnumerable<object> SearchDoctorsByLocationAndSpecialty(string locationName, string specialty)
        {
            var doctors = _repo.SearchDoctorsByLocationAndSpecialty(locationName, specialty);
            if (!doctors.Any())
                throw new DoctorSearchException($"No doctors found in '{locationName}' with specialty '{specialty}'.");

            return doctors;
        }

        public async Task<List<object>> GetDoctorsBySpecialityRatingAsync(string speciality)
        {
            return await _repo.GetDoctorsBySpecialityRatingAsync(speciality);
        }
    }
}