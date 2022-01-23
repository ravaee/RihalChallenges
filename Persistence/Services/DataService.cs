using Common.DTOs;
using Common.Middlewares;
using Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Services
{
    public class DataService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        

        public DataService(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

      
        public async Task refreshDatabase()
        {
            //Delete All classes
            var _classes = await _context.Classes.ToListAsync();
            _context.Classes.RemoveRange(_classes);


            //Delete All Students
            var _students = await _context.Students.ToListAsync();
            _context.Students.RemoveRange(_students);

            await _context.SaveChangesAsync();

            await ApplicationSeed.SeedCountries(_context);
            await ApplicationSeed.SeedClasses(_context);
            await ApplicationSeed.SeedAdminUser(_userManager);
        }

    }
}
