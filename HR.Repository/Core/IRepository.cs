using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HR.Entities.Core;

namespace HR.Repository.Core
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IQueryable<TEntity> GetAll();
        
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
 
        Task<TEntity> GetById(Guid id);
    
        Task Add(TEntity entity);
    
        Task Update(TEntity entity);
    
        Task Delete(Guid id);
    
        Task Delete(TEntity entity);
    }
}