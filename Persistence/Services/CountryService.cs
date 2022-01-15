using Common.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Services
{
    public class CountryService
    {
        private readonly ApplicationDbContext _context;
        public CountryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Country country)
        {

            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _context.Countries.ToListAsync();
        }

    }
}
