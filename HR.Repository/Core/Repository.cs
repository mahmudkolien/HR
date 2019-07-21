using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HR.Entities.Core;
using HR.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace HR.Repository.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly HRDbContext dbContext;

        public Repository(HRDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.dbContext.Set<TEntity>()
            .AsNoTracking().AsQueryable();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.dbContext.Set<TEntity>()
            .Where(predicate)
            .AsNoTracking().AsQueryable();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await this.dbContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity> GetById(Guid id, params Expression<Func<TEntity, object>>[] properties)
        {
            var query = this.dbContext.Set<TEntity>().AsQueryable();

            if(properties.Any())
                query = properties.Aggregate(query, (current, property) => current.Include(property));
            
            return await query.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
        
        public async Task Add(TEntity entity)
        {
            await this.dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Update(entity);
        }

        public async Task Delete(Guid id)
        {
            var entity = await GetById(id);
            this.dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task Delete(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Remove(entity);
        }
    }
}