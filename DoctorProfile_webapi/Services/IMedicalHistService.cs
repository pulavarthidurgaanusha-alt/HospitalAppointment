using HospitalAppointment.Models;


namespace HospitalAppointment.Services
{
    public interface IMedicalHistService
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
