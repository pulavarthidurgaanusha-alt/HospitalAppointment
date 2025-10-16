//using HospitalAppointment.Data;
using HospitalAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAppointment.Repository
{
    public class AvailabilityRepository : IAvailabilityRepository
    {
        private readonly Appointment_BookingContext _context;

        public AvailabilityRepository(Appointment_BookingContext context)
        {
            _context = context;
        }

        public List<Availability> GetAll() => _context.Availability.ToList();

        public Availability GetById(int id) => _context.Availability.FirstOrDefault(a => a.AvailabilityId == id);

        public void Add(Availability availability)
        {
            _context.Availability.Add(availability);
            _context.SaveChanges();
        }

        public void Update(Availability availability)
        {
            _context.Availability.Update(availability);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var slot = GetById(id);
            if (slot != null)
            {
                _context.Availability.Remove(slot);
                _context.SaveChanges();
            }
        }
        public bool DoctorExists(int doctorId)
        {
            return _context.Doctors.Any(d => d.DoctorId == doctorId);
        }

        public bool LocationExists(int locationId)
        {
            return _context.Location.Any(l => l.LocationId == locationId);
        }


        public List<Availability> SearchByDoctorId(int doctorId) =>
            _context.Availability.Where(a => a.DoctorId == doctorId).ToList();

        public List<Availability> SearchByLocationId(int locationId) =>
            _context.Availability.Where(a => a.LocationId == locationId).ToList();
        public List<Availability> SearchByLocationAndDoctorId(int locationId, int doctorId)
        {
            return _context.Availability
                .Where(a => a.LocationId == locationId && a.DoctorId == doctorId)
                .ToList();
        }

        public List<Availability> SearchByDateAndDoctorId(DateTime date, int doctorId)
        {
            return _context.Availability
                .Where(a => a.Date.Date == date.Date && a.DoctorId == doctorId)
                .ToList();
        }

        public List<Availability> SearchByDateDoctorLocation(DateTime date, int doctorId, int locationId)
        {
            return _context.Availability
                .Where(a => a.Date.Date == date.Date && a.DoctorId == doctorId && a.LocationId == locationId)
                .ToList();
        }

    }
}
