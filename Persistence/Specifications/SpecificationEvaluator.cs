using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Specifications
{
    internal class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if(spec.StringIncludes != null)
            {
                query = spec.StringIncludes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (spec.Includes != null)
            {
                query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            }           

            return query;
        }
    }
}
