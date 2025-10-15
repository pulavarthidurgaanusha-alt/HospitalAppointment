using HospitalAppointment.Models;
using System.Collections.Generic;
using System.Numerics;

namespace HospitalAppointment.Services
{
    public interface IDoctorService
    {
        void CreateDoctor(Doctor doctor);
        Doctor GetDoctorById(int id);
        IEnumerable<Doctor> GetAllDoctors();
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(int id);
        IEnumerable<object> SearchDoctorsByLocationAndSpecialty(string locationName, string specialty);
    }
}