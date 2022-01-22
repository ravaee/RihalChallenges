using Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public static class ApplicationSeed
    {
        public static async Task SeedCountries(ApplicationDbContext _context)
        {
            if(_context.Countries.Count() == 0)
            {
                var countries = new List<Country>();

                for (int i = 0; i < 100; i++)
                {
                    countries.Add(new Country()
                    {
                        Name = Faker.Country.Name()
                    });
                }

                await _context.Countries.AddRangeAsync(countries);
                await _context.SaveChangesAsync();

            }
        }

        public static async Task SeedClasses(ApplicationDbContext _context)
        {
            if (_context.Classes.Count() == 0)
            {
                var classes = new List<Class>() 
                { 
                    new Class() { Name = "Data Structure" },
                    new Class() { Name = "Web Design" },
                    new Class() { Name = "Game Development" },
                    new Class() { Name = ".NET" },
                };


                await _context.Classes.AddRangeAsync(classes);
                await _context.SaveChangesAsync();

            }
        }

        public static async Task SeedAdminUser(UserManager<ApplicationUser> userManager)
        {

            ApplicationUser AdminUser = new ApplicationUser()
            {

                UserName = "AdminUser@Email.com",
                Email = "AdminUser@Email.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var user = await userManager.FindByEmailAsync("test@gmail.com");

            if (user == null)
            {
                await userManager.CreateAsync(AdminUser, "Abcd@1234");
            }
        }

        
    }
}
