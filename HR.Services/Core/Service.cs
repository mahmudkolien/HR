using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR.Entities.Core;
using HR.Entities.NotMapped;
using HR.Repository.Contracts;
using HR.Repository.Core;

namespace HR.Services.Core
{
    public class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        private readonly IRepository<TEntity> repository;
        private readonly IUnitOfWork unitOfWork;

        public Service(IRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public virtual async Task<Guid> AddAsync(TEntity entity)
        {
            await this.repository.AddAsync(entity);
            await this.unitOfWork.CompleteAsync();
            return  entity.Id;
        }

        public virtual async Task<Guid> UpdateAsync(TEntity entity)
        {
            await this.repository.UpdateAsync(entity);
            await this.unitOfWork.CompleteAsync();
            return  entity.Id;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            await this.repository.DeleteAsync(id);
            return await this.unitOfWork.CompleteAsync();
        }

        public virtual async Task<QueryResult<TEntity>> GetAllAsync()
        {
            return await this.repository.GetAllAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await this.repository.GetByIdAsync(id);
        }
    }
}