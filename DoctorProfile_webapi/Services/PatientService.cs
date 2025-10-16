using HospitalAppointment.Models;
using HospitalAppointment.Repositories;

namespace HospitalAppointment.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public List<Patient> GetAllPatients()
        {
            return _repository.GetAllPatients();
        }

        public Patient GetPatientById(int patient_id)
        {
            return _repository.GetPatientById(patient_id);
        }

        public int AddPatient(Patient patient)
        {
            if (string.IsNullOrWhiteSpace(patient.Name))
                throw new ArgumentException("Patient name is required.");

            if (string.IsNullOrWhiteSpace(patient.Phone))
                throw new ArgumentException("Phone number is required.");

            return _repository.AddPatient(patient);
        }

        public int UpdatePatient(int id, Patient patient)
        {
            var existing = _repository.GetPatientById(id);
            if (existing == null)
                throw new KeyNotFoundException("Patient not found.");

            return _repository.UpdatePatient(id, patient);
        }

        public int DeletePatientById(int patient_id)
        {
            var existing = _repository.GetPatientById(patient_id);
            if (existing == null)
                throw new KeyNotFoundException("Patient not found.");

            return _repository.DeletePatientById(patient_id);
        }

        public int DeleteAllPatients()
        {
            return _repository.DeleteAllPatients();
        }
    }
}
