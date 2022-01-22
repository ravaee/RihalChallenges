using Common.Models;
using Persistence.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Interface.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseModel
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task Add(TEntity entity);
        Task AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<bool> Any(int Id);

        Task<IEnumerable<TEntity>> ListAsync(ISpecification<TEntity> spec);
    }
}
