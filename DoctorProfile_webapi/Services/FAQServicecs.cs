using HospitalAppointment.Models;
using System.Collections.Generic;
//using webapi.IServices;
//using webapi.Models;
//using webapi.IRepository;
//using webapi.IServices;

namespace HospitalAppointment.Services
{
    public class FAQService : IFAQService
    {
        private readonly IFAQRepository _repository;

        public FAQService(IFAQRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<FAQ> GetAllFAQs()
        {
            return _repository.GetAllAsync().Result;
        }

        public FAQ GetFAQById(int id)
        {
            return _repository.GetByIdAsync(id).Result;
        }

        public void CreateFAQ(FAQ faq)
        {
            _repository.AddAsync(faq).Wait();
        }

        public void UpdateFAQ(int id, FAQ faq)
        {
            faq.FaqId = id;
            _repository.UpdateAsync(faq).Wait();
        }

        public void DeleteFAQ(int id)
        {
            _repository.DeleteAsync(id).Wait();
        }
    }
}