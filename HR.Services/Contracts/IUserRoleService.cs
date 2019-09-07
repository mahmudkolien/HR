using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR.Entities;
using HR.Entities.NotMapped;
using HR.Services.Core;

namespace HR.Services.Contracts
{
    public interface IUserRoleService : IService<UserRole>
    {
        Task<QueryResult<UserRole>> GetAllAsync(UserRoleQuery query);
        Task<IEnumerable<UserRolePermission>> GetRolePermissionsByRoleIdAsync(Guid id);
    }
}