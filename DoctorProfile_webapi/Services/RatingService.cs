using HospitalAppointment.Models;
using HospitalAppointment.Repository;
using System;
using System.Collections.Generic;
//using webapi.Models;
//sing webapi.IRepository;
//using webapi.IServices;

namespace HospitalAppointment.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public List<Rating> GetAllRatings()
        {
            return _ratingRepository.GetAllRatings();
        }

        public Rating GetRatingById(int id)
        {
            return _ratingRepository.GetRatingById(id);
        }

        public List<Rating> GetHighestRatings()
        {
            return _ratingRepository.GetHighestRatings();
        }

        public int AddRating(Rating rating)
        {
            if (rating.Value < 1 || rating.Value > 5)
            {
                throw new ArgumentException("Rating value must be between 1 and 5.");
            }

            rating.CreatedAt = DateTime.Now;
            return _ratingRepository.AddRating(rating);
        }

        public bool UpdateRating(Rating rating)
        {
            if (rating.Value < 1 || rating.Value > 5)
            {
                throw new ArgumentException("Rating value must be between 1 and 5.");
            }

            return _ratingRepository.UpdateRating(rating);
        }

        public bool DeleteRating(int id)
        {
            return _ratingRepository.DeleteRating(id);
        }
    }
}