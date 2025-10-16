//using HospitalAppointment.Data;
using HospitalAppointment.Models;
using HospitalAppointment.Models;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAppointment.Repositories
{
    public class MedicalHistRepository : IMedicalHistRepository
    {
        private readonly Appointment_BookingContext _context;

        public MedicalHistRepository(Appointment_BookingContext context)
        {
            _context = context;
        }

        public List<MedicalHist> GetAllMedicalHistories()
        {
            return _context.MedicalHist.ToList();
        }

        public MedicalHist GetMedicalHistoryById(int historyId)
        {
            return _context.MedicalHist.FirstOrDefault(h => h.HistoryId == historyId);
        }

        public List<MedicalHist> GetMedicalHistoriesByPatientId(int patientId)
        {
            return _context.MedicalHist
                .Where(h => h.PatientId == patientId)
                .ToList();
        }

        public int AddMedicalHistory(MedicalHist history)
        {
            _context.MedicalHist.Add(history);
            return _context.SaveChanges();
        }
        


        public int UpdateMedicalHistory(int id, MedicalHist history)
        {
            var existingHistory = _context.MedicalHist.Find(id);
            if (existingHistory == null) return 0;

            existingHistory.Diagnosis = history.Diagnosis;
            existingHistory.Treatment = history.Treatment;
            existingHistory.DateOfVisit = history.DateOfVisit;
            existingHistory.PatientId = history.PatientId;
            existingHistory.DoctorId = history.DoctorId;

            return _context.SaveChanges();
        }

        public int DeleteMedicalHistoryById(int historyId)
        {
            var history = _context.MedicalHist.Find(historyId);
            if (history == null) return 0;

            _context.MedicalHist.Remove(history);
            return _context.SaveChanges();
        }

        public int DeleteAllMedicalHistories()
        {
            var allHistories = _context.MedicalHist.ToList();
            _context.MedicalHist.RemoveRange(allHistories);
            return _context.SaveChanges();
        }

        public List<MedicalHist> SearchMedicalHistories(string keyword)
        {
            return _context.MedicalHist
                .Where(h => h.Diagnosis.Contains(keyword) || h.Treatment.Contains(keyword))
                .ToList();
        }
    }
}
