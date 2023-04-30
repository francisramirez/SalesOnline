using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SalesOnline.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetEntityById(int Id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Find(Expression<Func<TEntity, bool>> filter);
        Task Save(TEntity entity);
        Task Save(params TEntity[] entities);
        Task Update(TEntity entity);
        Task Update(params TEntity[] entities);

        Task<bool> Exists(Expression<Func<TEntity, bool>> filter);
        Task SaveChanges();

    }
}
