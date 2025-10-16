using HospitalAppointment.Models;
using System.Collections.Generic;
using System.Linq;
//using webapi.Data;
//using webapi.Models;
//using webapi.IRepository;

namespace HospitalAppointment.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly Appointment_BookingContext _context;

        public RatingRepository(Appointment_BookingContext context)
        {
            _context = context;
        }

        public List<Rating> GetAllRatings()
        {
            return _context.Rating.ToList();
        }

        public Rating GetRatingById(int id)
        {
            return _context.Rating.FirstOrDefault(r => r.RatingId == id);
        }

        public List<Rating> GetHighestRatings()
        {
            return _context.Rating
                .OrderByDescending(r => r.Value)
                .ToList();
        }

        public int AddRating(Rating rating)
        {
            _context.Rating.Add(rating);
            _context.SaveChanges();
            return rating.RatingId;
        }

        public bool UpdateRating(Rating rating)
        {
            var existing = _context.Rating.Find(rating.RatingId);
            if (existing == null) return false;

            existing.DoctorId = rating.DoctorId;
            existing.PatientId = rating.PatientId;
            existing.Value = rating.Value;
            existing.Feedback = rating.Feedback;
            existing.CreatedAt = rating.CreatedAt;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteRating(int id)
        {
            var rating = _context.Rating.Find(id);
            if (rating == null) return false;

            _context.Rating.Remove(rating);
            _context.SaveChanges();
            return true;
        }
    }
}