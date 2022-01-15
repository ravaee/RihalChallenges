using Common.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Services
{
    public class ClassService
    {
        private readonly ApplicationDbContext _context;
        public ClassService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(Class @class)
        {

            await _context.Classes.AddAsync(@class);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Class>> GetAll()
        {
            var classes = await _context.Classes.ToListAsync();
            return classes;
        }
    }
}
