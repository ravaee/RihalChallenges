using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Specifications.EntitySpecs
{
    public class CountryWithStudentSpecification : Specification<Country>
    {
        public CountryWithStudentSpecification()
        {
            AddInclude(x => x.Students);
        }
    }

    public class CountryWithAtListOneStudentSpecification : Specification<Country>
    {
        public CountryWithAtListOneStudentSpecification()
        {
            AddCriteria(x => x.Students.Count > 0);
            AddInclude(x => x.Students);
        }
    }
}
