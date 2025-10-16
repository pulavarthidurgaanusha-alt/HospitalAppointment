using HospitalAppointment.Models;

namespace HospitalAppointment.Repositories
{
    public interface IMedicalHistRepository
    {
        List<MedicalHist> GetAllMedicalHistories();
        MedicalHist GetMedicalHistoryById(int historyId);
        List<MedicalHist> GetMedicalHistoriesByPatientId(int patientId);
        List<MedicalHist> SearchMedicalHistories(string keyword);
        int AddMedicalHistory(MedicalHist history);
        int UpdateMedicalHistory(int id, MedicalHist history);
        int DeleteMedicalHistoryById(int historyId);
        int DeleteAllMedicalHistories();
    }
}
