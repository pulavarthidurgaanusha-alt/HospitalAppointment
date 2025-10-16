using HospitalAppointment.Models;

namespace HospitalAppointment.Repositories
{
    public interface IPatientRepository
    {
        public List<Patient> GetAllPatients();
        public Patient GetPatientById(int patient_id);
        public int AddPatient(Patient patient);
        public int UpdatePatient(int id, Patient patient);
        public int DeletePatientById(int patient_id);
        public int DeleteAllPatients();

    }
}
