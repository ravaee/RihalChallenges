using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Specifications.EntitySpecs
{
    public class StudentWithCountriesAndClassSpecification: Specification<Student>
    {
        public StudentWithCountriesAndClassSpecification()
        {
            AddInclude(x => x.Country);
            AddInclude(x => x.Class);
        }
    }
}
