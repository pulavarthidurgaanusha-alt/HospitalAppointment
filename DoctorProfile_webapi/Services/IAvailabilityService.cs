using HospitalAppointment.Models;

namespace HospitalAppointment.Services
{
    public interface IAvailabilityService
    {
        List<Availability> GetAll();
        Availability GetById(int id);
        void Add(Availability availability);
        
        void Update(Availability availability);
        void Delete(int id);
        //List<Availability> Search(int? doctorId, int? locationId, DateTime? date, TimeSpan? startTime, TimeSpan? endTime, SlotStatus? status);
        List<Availability> SearchByDoctorId(int doctorId);
        List<Availability> SearchByLocationId(int locationId);
        List<Availability> SearchByLocationAndDoctorId(int locationId, int doctorId);

        
        List<Availability> SearchByDateAndDoctorId(DateTime date, int doctorId);

        List<Availability> SearchByDateDoctorLocation(DateTime date, int doctorId, int locationId);

    }
}