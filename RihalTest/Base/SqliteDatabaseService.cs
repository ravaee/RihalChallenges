using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.UnitOfWork;
using RihalChallenges;
using Xunit;

namespace RihalTest
{
    public class SqliteDatabaseService: ItemServiceUT
    {
        protected readonly IMapper _mapper;
        protected readonly IRepositoryUnitOfWork _work;
        public SqliteDatabaseService()
            : base(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite("Filename=Test.db")
                .Options)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
            });

            _mapper = mappingConfig.CreateMapper();
            _work = new RepositoryUnitOfWork(new ApplicationDbContext(_contextOptions));
        }

    }
}