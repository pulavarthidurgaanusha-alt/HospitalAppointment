using HospitalAppointment.Models;
using Microsoft.EntityFrameworkCore;
using System;
//using webapi.Data;
//using webapi.Models;

public class FAQRepository : IFAQRepository
{
    private readonly Appointment_BookingContext _context;

    public FAQRepository(Appointment_BookingContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FAQ>> GetAllAsync()
    {
        return await _context.FAQs.ToListAsync();
    }

    public async Task<FAQ> GetByIdAsync(int id)
    {
        return await _context.FAQs.FindAsync(id);
    }

    public async Task<FAQ> AddAsync(FAQ faq)
    {
        _context.FAQs.Add(faq);
        await _context.SaveChangesAsync();
        return faq;
    }

    public async Task<FAQ> UpdateAsync(FAQ faq)
    {
        _context.FAQs.Update(faq);
        await _context.SaveChangesAsync();
        return faq;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var faq = await _context.FAQs.FindAsync(id);
        if (faq == null) return false;

        _context.FAQs.Remove(faq);
        await _context.SaveChangesAsync();
        return true;
    }
}
