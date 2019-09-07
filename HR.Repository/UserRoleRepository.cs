using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Entities;
using HR.Repository.Context;
using HR.Repository.Contracts;
using HR.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace HR.Repository
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        private readonly HRDbContext dbContext;

        public UserRoleRepository(HRDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task DeleteRolePermissionsFromDBByRoleIdAsync(Guid id)
        {
            var rolePermissions = await this.dbContext.UserRolePermissions.Where(x => x.RoleId == id).AsNoTracking().ToListAsync();
            if(rolePermissions.Any())
                this.dbContext.UserRolePermissions.RemoveRange(rolePermissions);
        }

        public async Task DeleteRolePermissionsFromDBAsync(IEnumerable<UserRolePermission> rolePermissions)
        {
            this.dbContext.UserRolePermissions.RemoveRange(rolePermissions);
        }

        public async Task AddRolePermissionsAsync(IEnumerable<UserRolePermission> rolePermissions)
        {
            await this.dbContext.UserRolePermissions.AddRangeAsync(rolePermissions);
        }

        public async Task<IEnumerable<UserRolePermission>> GetRolePermissionsByRoleIdAsync(Guid id)
        {
            return await this.dbContext.UserRolePermissions.Where(x => x.RoleId == id).AsNoTracking().ToListAsync();
        }
    }
}