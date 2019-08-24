using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HR.Entities.Core;
using HR.Entities.NotMapped;
using HR.Repository.Context;
using HR.Repository.Extensions;
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

        public virtual async Task<QueryResult<TEntity>> GetAllAsync(
            bool includeRelated = false,
            IQueryObject queryObj = null,
            Dictionary<string, Expression<Func<TEntity, object>>> columnsMap = null)
        {
            var query = this.dbContext.Set<TEntity>().AsQueryable();
            var result = new QueryResult<TEntity>();

            if(includeRelated)
            {
                foreach (var property in this.dbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                    query = query.Include(property.Name);
            }

            result.TotalItems = await query.CountAsync();
            query = query.ApplyOrdering(queryObj, columnsMap);
            query = query.ApplyPaging(queryObj);
            result.Items = await query.AsNoTracking().ToListAsync();

            return result;
        }

        public virtual async Task<QueryResult<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate,
            bool includeRelated = false,
            IQueryObject queryObj = null,
            Dictionary<string, Expression<Func<TEntity, object>>> columnsMap = null)
        {
            var query = this.dbContext.Set<TEntity>().AsQueryable();
            var result = new QueryResult<TEntity>();

            if(includeRelated)
            {
                foreach (var property in this.dbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                    query = query.Include(property.Name);
            }

            query = query.Where(predicate);
            result.TotalItems = await query.CountAsync();
            query = query.ApplyOrdering(queryObj, columnsMap);
            query = query.ApplyPaging(queryObj);
            result.Items = await query.AsNoTracking().ToListAsync();

            return result;
        }

        public virtual async Task<QueryResult<TEntity>> GetAllAsync(
            IQueryObject queryObj = null,
            Dictionary<string, Expression<Func<TEntity, object>>> columnsMap = null,
            params Expression<Func<TEntity, object>>[] properties)
        {
            var query = this.dbContext.Set<TEntity>().AsQueryable();
            var result = new QueryResult<TEntity>();

            if(properties.Any())
                query = properties.Aggregate(query, (current, property) => current.Include(property));

            result.TotalItems = await query.CountAsync();
            query = query.ApplyOrdering(queryObj, columnsMap);
            query = query.ApplyPaging(queryObj);
            result.Items = await query.AsNoTracking().ToListAsync();

            return result;
        }

        public virtual async Task<QueryResult<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> predicate,
            IQueryObject queryObj = null,
            Dictionary<string, Expression<Func<TEntity, object>>> columnsMap = null,
            params Expression<Func<TEntity, object>>[] properties)
        {
            var query = this.dbContext.Set<TEntity>().AsQueryable();
            var result = new QueryResult<TEntity>();

            if(properties.Any())
                query = properties.Aggregate(query, (current, property) => current.Include(property));

            query = query.Where(predicate);
            result.TotalItems = await query.CountAsync();
            query = query.ApplyOrdering(queryObj, columnsMap);
            query = query.ApplyPaging(queryObj);
            result.Items = await query.AsNoTracking().ToListAsync();

            return result;
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id, bool includeRelated = false)
        {
            var query = this.dbContext.Set<TEntity>().AsQueryable();

            if(includeRelated)
            {
                foreach (var property in this.dbContext.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                    query = query.Include(property.Name);
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] properties)
        {
            var query = this.dbContext.Set<TEntity>().AsQueryable();

            if(properties.Any())
                query = properties.Aggregate(query, (current, property) => current.Include(property));
            
            return await query.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
        
        public virtual async Task AddAsync(TEntity entity)
        {
            await this.dbContext.Set<TEntity>().AddAsync(entity);
        }
        
        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await this.dbContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Update(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            await this.DeleteAsync(entity);
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            await this.UpdateAsync(entity);
        }

        public virtual async Task DeleteFromDBAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            await this.DeleteFromDBAsync(entity);
        }

        public virtual async Task DeleteFromDBAsync(TEntity entity)
        {
            this.dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual async Task DeleteRangeFromDBAsync(IEnumerable<TEntity> entities)
        {
            this.dbContext.Set<TEntity>().RemoveRange(entities);
        }
    }
}