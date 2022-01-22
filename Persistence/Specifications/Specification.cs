using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Persistence.Specifications
{
    public class Specification<T> : ISpecification<T>
    {
        public Specification()
        {

        }


        public Expression<Func<T, bool>> Criteria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; } = new();

        public List<string> StringIncludes { get; } = new();

        public void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }
        public void AddInclude(string includeString)
        {
            StringIncludes.Add(includeString);
        }
        public void AddCriteria(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
    }
}
