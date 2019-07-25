using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool includeRelated = false)
        {
            var query = this.dbContext.Set<TEntity>().AsQueryable();

            if(includeRelated)
            {
                foreach (var property in this.dbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                    query = query.Include(property.Name);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, bool includeRelated = false)
        {
            var query = this.dbContext.Set<TEntity>().AsQueryable();

            if(includeRelated)
            {
                foreach (var property in this.dbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                    query = query.Include(property.Name);
            }

            return await query.Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] properties)
        {
            var query = this.dbContext.Set<TEntity>().AsQueryable();

            if(properties.Any())
                query = properties.Aggregate(query, (current, property) => current.Include(property));

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] properties)
        {
            var query = this.dbContext.Set<TEntity>().AsQueryable();

            if(properties.Any())
                query = properties.Aggregate(query, (current, property) => current.Include(property));

            return await query.Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id, bool includeRelated = false)
        {
            var query = this.dbContext.Set<TEntity>().AsQueryable();

            if(includeRelated)
            {
                foreach (var property in this.dbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                    query = query.Include(property.Name);
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] properties)
        {
            var query = this.dbContext.Set<TEntity>().AsQueryable();

            if(properties.Any())
                query = properties.Aggregate(query, (current, property) => current.Include(property));
            
            return await query.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
        
        public async Task AddAsync(TEntity entity)
        {
            await this.dbContext.Set<TEntity>().AddAsync(entity);
        }
        
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await this.dbContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Update(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            await this.DeleteAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            await this.UpdateAsync(entity);
        }

        public async Task DeleteFromDBAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            await this.DeleteFromDBAsync(entity);
        }

        public async Task DeleteFromDBAsync(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Remove(entity);
        }

        public async Task DeleteRangeFromDBAsync(IEnumerable<TEntity> entities)
        {
            this.dbContext.Set<TEntity>().RemoveRange(entities);
        }
    }
}