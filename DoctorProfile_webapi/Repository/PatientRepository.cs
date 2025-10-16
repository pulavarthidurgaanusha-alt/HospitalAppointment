//using HospitalAppointment.Data;
using HospitalAppointment.Models;

namespace HospitalAppointment.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly Appointment_BookingContext _context;

        public PatientRepository(Appointment_BookingContext context)
        {
            _context = context;
        }

        public List<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        public Patient GetPatientById(int patient_id)
        {
            return _context.Patients.FirstOrDefault(p => p.PatientId == patient_id);
        }

        public int AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            return _context.SaveChanges();
        }

        public int UpdatePatient(int id, Patient updatedPatient)
        {
            var existingPatient = _context.Patients.Find(id);
            if (existingPatient == null) return 0;

            existingPatient.Name = updatedPatient.Name;
            existingPatient.Phone = updatedPatient.Phone;
            existingPatient.Gender = updatedPatient.Gender;
            existingPatient.Dob = updatedPatient.Dob;
            existingPatient.Address = updatedPatient.Address;
            existingPatient.UserId = updatedPatient.UserId;

            return _context.SaveChanges();
        }

        public int DeletePatientById(int patient_id)
        {
            var patient = _context.Patients.Find(patient_id);
            if (patient == null) return 0;

            _context.Patients.Remove(patient);
            return _context.SaveChanges();
        }

        public int DeleteAllPatients()
        {
            var allPatients = _context.Patients.ToList();
            _context.Patients.RemoveRange(allPatients);
            return _context.SaveChanges();
        }
    }
}
