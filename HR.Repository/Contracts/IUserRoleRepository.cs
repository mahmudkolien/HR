using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR.Entities;
using HR.Repository.Core;

namespace HR.Repository.Contracts
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        Task DeleteRolePermissionsFromDBAsync(ICollection<UserRolePermission> rolePermissions);
        Task DeleteRolePermissionsFromDBByRoleIdAsync(Guid id);
        Task AddRolePermissionsAsync(ICollection<UserRolePermission> rolePermissions);
    }
}