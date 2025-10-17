using HospitalAppointment.Models;
using System.Collections.Generic;
//using webapi.Models;

namespace HospitalAppointment.Repository
{
    public interface IRatingRepository
    {
        List<Rating> GetAllRatings();
        Rating GetRatingById(int id);
        List<Rating> GetHighestRatings(); // returns all ratings ordered by value descending
        int AddRating(Rating rating);
        bool UpdateRating(Rating rating);
        bool DeleteRating(int id);
    }
}