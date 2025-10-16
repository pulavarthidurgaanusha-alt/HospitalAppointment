//using webapi.Models;

using HospitalAppointment.Models;

public interface IFAQRepository
{
    Task<IEnumerable<FAQ>> GetAllAsync();
    Task<FAQ> GetByIdAsync(int id);
    Task<FAQ> AddAsync(FAQ faq);
    Task<FAQ> UpdateAsync(FAQ faq);
    Task<bool> DeleteAsync(int id);
}

