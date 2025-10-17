using HospitalAppointment.Models;
using System.Collections.Generic;
//using webapi.Models;

namespace HospitalAppointment.Services
{
    public interface IFAQService
    {
        IEnumerable<FAQ> GetAllFAQs();
        FAQ GetFAQById(int id);
        void CreateFAQ(FAQ faq);
        void UpdateFAQ(int id, FAQ faq);
        void DeleteFAQ(int id);
    }
}