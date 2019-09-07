using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HR.Common;
using HR.Entities;
using HR.Entities.NotMapped;
using HR.Repository.Contracts;
using HR.Repository.Core;
using HR.Services.Contracts;
using HR.Services.Core;

namespace HR.Services
{
    public class UserRoleService : Service<UserRole>, IUserRoleService
    {
        private readonly IUserRoleRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public UserRoleService(IUserRoleRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public override async Task<Guid> AddAsync(UserRole entity)
        {
            entity.Status = (int)EnumUserRoleStatus.GeneralUser;
            return  await base.AddAsync(entity);
        }

        public override async Task<Guid> UpdateAsync(UserRole entity)
        {
            // Remove Previous Role Permissions
            await this.repository.DeleteRolePermissionsFromDBByRoleIdAsync(entity.Id);
            //await this.unitOfWork.CompleteAsync();
            // Add New Role Permissions
            entity.UserRolePermissions.ToList().ForEach(x => x.RoleId = entity.Id);
            await this.repository.AddRolePermissionsAsync(entity.UserRolePermissions);
            //await this.unitOfWork.CompleteAsync();

            entity.UpdatedOn = DateTime.Now;
            return  await base.UpdateAsync(entity);
        }

        public async Task<QueryResult<UserRole>> GetAllAsync(UserRoleQuery query)
        {
            var columnsMap = new Dictionary<string, Expression<Func<UserRole, object>>>()
            {
                ["name"] = v => v.RoleName
            };
            
            return  await this.repository.GetAllAsync(x => 
                !x.IsDeleted && 
                x.Status != (int)EnumUserStatus.SuperAdmin && 
                (string.IsNullOrWhiteSpace(query.Name) || x.RoleName.Contains(query.Name)), 
                false, query, columnsMap);
        }

        public override async Task<UserRole> GetByIdAsync(Guid id)
        {
            return await this.repository.GetByIdAsync(id, x => x.UserRolePermissions);
        }
    }
}