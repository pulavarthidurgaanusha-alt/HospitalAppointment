using HospitalAppointment.Exceptions;
using HospitalAppointment.Models;
using HospitalAppointment.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAppointment.Services
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IAvailabilityRepository _repo;

        public AvailabilityService(IAvailabilityRepository repo)
        {
            _repo = repo;
        }

        public List<Availability> GetAll() => _repo.GetAll();

        public Availability GetById(int id)
        {
            var slot = _repo.GetById(id);
            if (slot == null)
                throw new AvailabilityNotFoundException(id);

            return slot;
        }

        public void Add(Availability availability)
        {
            if (availability == null)
                throw new AvailabilityNullException(nameof(availability));

            if (availability.EndTime <= availability.StartTime)
                throw new InvalidAvailabilityTimeException();

            bool doctorExists = _repo.DoctorExists(availability.DoctorId);
            bool locationExists = _repo.LocationExists(availability.LocationId);

            if (!doctorExists && !locationExists)
                throw new DoctorAndLocationNotFoundException(availability.DoctorId, availability.LocationId);

            if (!doctorExists)
                throw new DoctorNotFoundException(availability.DoctorId);

            if (!locationExists)
                throw new LocationNotFoundException(availability.LocationId, "Add");

            bool conflict = _repo.SearchByDoctorId(availability.DoctorId)
                .Any(slot =>
                    slot.LocationId == availability.LocationId &&
                    slot.Date.Date == availability.Date.Date &&
                    availability.StartTime < slot.EndTime &&
                    availability.EndTime > slot.StartTime
                );

            if (conflict)
                throw new AvailabilityConflictException(availability.Date, availability.StartTime);

            _repo.Add(availability);
        }

        public void Update(Availability availability)
        {
            if (availability == null)
                throw new ArgumentNullException(nameof(availability));

            if (availability.EndTime <= availability.StartTime)
                throw new InvalidAvailabilityTimeException();

            bool doctorExists = _repo.DoctorExists(availability.DoctorId);
            bool locationExists = _repo.LocationExists(availability.LocationId);

            if (!doctorExists)
                throw new DoctorAvailabilityNotFoundException(availability.DoctorId);

            if (!locationExists)
                throw new LocationNotFoundException(availability.LocationId, "Update");

            _repo.Update(availability);
        }

        public void Delete(int id)
        {
            var existing = _repo.GetById(id);
            if (existing == null)
                throw new AvailabilityNotFoundException(id);

            _repo.Delete(id);
        }

        public List<Availability> SearchByDoctorId(int doctorId)
        {
            var results = _repo.SearchByDoctorId(doctorId);
            if (results.Count == 0)
                throw new DoctorAvailabilityNotFoundException(doctorId);
            return results;
        }

        public List<Availability> SearchByLocationId(int locationId)
        {
            var results = _repo.SearchByLocationId(locationId);
            if (results.Count == 0)
                throw new LocationNotFoundException(locationId, "Search");
            return results;
        }

        public List<Availability> SearchByLocationAndDoctorId(int locationId, int doctorId)
        {
            var results = _repo.SearchByLocationAndDoctorId(locationId, doctorId);
            if (results.Count == 0)
                throw new DoctorLocationAvailabilityNotFoundException(doctorId, locationId);

            return results;
        }

        public List<Availability> SearchByDateAndDoctorId(DateTime date, int doctorId)
        {
            var results = _repo.SearchByDateAndDoctorId(date, doctorId);
            if (results.Count == 0)
                throw new DateDoctorAvailabilityNotFoundException(date, doctorId);
            return results;
        }

        public List<Availability> SearchByDateDoctorLocation(DateTime date, int doctorId, int locationId)
        {
            var results = _repo.SearchByDateDoctorLocation(date, doctorId, locationId);
            if (results.Count == 0)
                throw new DateDoctorLocationAvailabilityNotFoundException(date, doctorId, locationId);

            return results;
        }
    }
}

