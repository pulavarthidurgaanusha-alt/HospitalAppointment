using HospitalAppointment.Models;
using HospitalAppointment.Repositories;
//using System.ComponentModel.DataAnnotations;
using HospitalAppointment.Exceptions;
using HospitalAppointment.Services;




namespace HospitalAppointment.Services
{
    public class MedicalHistService : IMedicalHistService
    {
        private readonly IMedicalHistRepository _repository;

        public MedicalHistService(IMedicalHistRepository repository)
        {
            _repository = repository;
        }

        public List<MedicalHist> GetAllMedicalHistories()
        {
            return _repository.GetAllMedicalHistories();
        }

        public MedicalHist GetMedicalHistoryById(int historyId)
        {
            var history = _repository.GetMedicalHistoryById(historyId);
            if (history == null)
                throw new NotFoundException("Medical history not found.");
            return history;
        }

        public List<MedicalHist> GetMedicalHistoriesByPatientId(int patientId)
        {
            return _repository.GetMedicalHistoriesByPatientId(patientId);
        }

        public List<MedicalHist> SearchMedicalHistories(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                throw new ValidationException("Search keyword cannot be empty.");
            return _repository.SearchMedicalHistories(keyword);
        }

        public int AddMedicalHistory(MedicalHist history)
        {
            if (history.PatientId <= 0 || history.DoctorId <= 0)
                throw new ValidationException("Patient and Doctor IDs are required.");
            return _repository.AddMedicalHistory(history);
        }

        public int UpdateMedicalHistory(int id, MedicalHist history)
        {
            var existing = _repository.GetMedicalHistoryById(id);
            if (existing == null)
                throw new NotFoundException("Medical history not found.");

            if (existing.DoctorId != history.DoctorId)
                throw new DoctorAuthorizationException("Doctor not authorized to update this record.");

            return _repository.UpdateMedicalHistory(id, history);
        }

        public int DeleteMedicalHistoryById(int historyId)
        {
            var existing = _repository.GetMedicalHistoryById(historyId);
            if (existing == null)
                throw new NotFoundException("Medical history not found.");
            return _repository.DeleteMedicalHistoryById(historyId);
        }

        public int DeleteAllMedicalHistories()
        {
            return _repository.DeleteAllMedicalHistories();
        }
    }
}

