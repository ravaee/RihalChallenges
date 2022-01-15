using Persistence.Context;
using Persistence.Interface.Repository;
using Persistence.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWork
{
    public class RepositoryUnitOfWork : IRepositoryUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public IStudentRepository StudentRepository { get; set; }
        public ICountryRepository CountryRepository { get; set; }
        public IClassRepository ClassRepository { get; set; }

        public RepositoryUnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            StudentRepository = new StudentRepository(context);
            CountryRepository = new CountryRepository(context);
            ClassRepository = new ClassRespository(context);
        }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
