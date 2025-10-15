using HospitalAppointment.Models;
using System.Collections.Generic;
using System.Numerics;

namespace HospitalAppointment.Repository
{
    public interface IDoctorRepository
    {
        void CreateDoctor(Doctor doctor);
        Doctor GetDoctorById(int id);
        IEnumerable<Doctor> GetAllDoctors();
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(int id);
        bool ExistsByName(string name);
        IEnumerable<object> SearchDoctorsByLocationAndSpecialty(string locationName, string specialty);
    }
}