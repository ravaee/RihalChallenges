using Common.Models;
using Persistence.Context;
using Persistence.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Impl
{
    public class ClassRespository : BaseRepository<Class>, IClassRepository
    {
        public ClassRespository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
