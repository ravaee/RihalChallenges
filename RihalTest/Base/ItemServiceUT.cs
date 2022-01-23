using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RihalTest
{
    public class ItemServiceUT
    {
        protected DbContextOptions<ApplicationDbContext> _contextOptions { get; }

        protected ItemServiceUT(DbContextOptions<ApplicationDbContext> contextOption)
        {
            _contextOptions = contextOption;

            Seed().Wait();
        }

        private async Task Seed()
        {
            using (var context = new ApplicationDbContext(_contextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                await DataService.RefreshTestDatabase(context);


                context.SaveChanges();
            }
        }


    }
}
