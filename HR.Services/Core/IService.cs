using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR.Entities.NotMapped;

namespace HR.Services.Core
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<Guid> AddAsync(TEntity entity);
        Task<Guid> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<QueryResult<TEntity>> GetAllAsync();
    }
}