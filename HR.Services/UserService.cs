using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HR.Common;
using HR.Entities;
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

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            return  await this.repository.GetAllAsync(x => x.Status != (int)EnumUserStatus.SuperAdmin, x => x.UserRole);
        }
    }
}