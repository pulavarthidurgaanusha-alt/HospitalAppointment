using HospitalAppointment.Models;

namespace HospitalAppointment.Services
{
    public interface IPatientService
    {
        List<Patient> GetAllPatients();
        Patient GetPatientById(int patient_id);
        int AddPatient(Patient patient);
        int UpdatePatient(int id, Patient patient);
        int DeletePatientById(int patient_id);
        int DeleteAllPatients();

    }
}
