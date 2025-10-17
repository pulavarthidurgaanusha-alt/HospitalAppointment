using HospitalAppointment.Models;
using System.Collections.Generic;
//using webapi.Models;

namespace HospitalAppointment.Services
{
    public interface IRatingService
    {
        List<Rating> GetAllRatings();
        Rating GetRatingById(int id);
        List<Rating> GetHighestRatings();
        int AddRating(Rating rating);
        bool UpdateRating(Rating rating);
        bool DeleteRating(int id);
    }
}