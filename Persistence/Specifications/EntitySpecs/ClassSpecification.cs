using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Specifications.EntitySpecs
{
    public class ClassWithStudentsSpecification: Specification<Class>
    {
        public ClassWithStudentsSpecification()
        {
            AddInclude(x => x.Students);
        }
    }

    public class ClassWithAtListOneStudentSpecification : Specification<Class>
    {
        public ClassWithAtListOneStudentSpecification()
        {
            AddCriteria(x => x.Students.Count > 0);
            AddInclude(x => x.Students);
        }
    }
}
