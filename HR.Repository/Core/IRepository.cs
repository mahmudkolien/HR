using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HR.Entities.Core;
using HR.Entities.NotMapped;

namespace HR.Repository.Core
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<QueryResult<TEntity>> GetAllAsync(
            bool includeRelated = false,
            IQueryObject queryObj = null,
            Dictionary<string, Expression<Func<TEntity, object>>> columnsMap = null);
        
        Task<QueryResult<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate, 
            bool includeRelated = false,
            IQueryObject queryObj = null,
            Dictionary<string, Expression<Func<TEntity, object>>> columnsMap = null);
        
        Task<QueryResult<TEntity>> GetAllAsync(
            IQueryObject queryObj = null,
            Dictionary<string, Expression<Func<TEntity, object>>> columnsMap = null,
            params Expression<Func<TEntity, object>>[] properties);
        
        Task<QueryResult<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate,
            IQueryObject queryObj = null,
            Dictionary<string, Expression<Func<TEntity, object>>> columnsMap = null,
            params Expression<Func<TEntity, object>>[] properties);
 
        Task<TEntity> GetByIdAsync(Guid id, bool includeRelated = false);

        Task<TEntity> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] properties);
    
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
    
        Task UpdateAsync(TEntity entity);
    
        Task DeleteAsync(Guid id);
    
        Task DeleteAsync(TEntity entity);
    
        Task DeleteFromDBAsync(Guid id);
    
        Task DeleteFromDBAsync(TEntity entity);
        Task DeleteRangeFromDBAsync(IEnumerable<TEntity> entities);
    }
}