using System;
using System.Collections.Generic;
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
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public override async Task<Guid> AddAsync(User entity)
        {
            // set default password with encrypted value
            entity.Password = DefaultValue.UserPassword.ToHash();
            return  await base.AddAsync(entity);
        }

        public override async Task<Guid> UpdateAsync(User entity)
        {
            entity.UpdatedOn = DateTime.Now;
            return  await base.UpdateAsync(entity);
        }

        public async Task<QueryResult<User>> GetAllAsync(UserQuery query)
        {
            var columnsMap = new Dictionary<string, Expression<Func<User, object>>>()
            {
                ["name"] = v => v.FullName,
                ["userName"] = v => v.UserName,
                ["email"] = v => v.Email
            };
            
            return  await this.repository.GetAllAsync(x => 
                !x.IsDeleted && 
                x.Status != (int)EnumUserStatus.SuperAdmin && 
                (string.IsNullOrWhiteSpace(query.Name) || x.FullName.Contains(query.Name)), 
                query, columnsMap, x => x.UserRole);
        }

        public override async Task<User> GetByIdAsync(Guid id)
        {
            return await this.repository.GetByIdAsync(id, x => x.UserRole);
        }
    }
}