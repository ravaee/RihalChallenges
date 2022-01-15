using Persistence.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWork
{
    public interface IRepositoryUnitOfWork: IDisposable
    {
        public IStudentRepository StudentRepository { get; set; }
        public ICountryRepository CountryRepository { get; set; }
        public IClassRepository ClassRepository { get; set; }

        Task<int> Complete();
    }
}
