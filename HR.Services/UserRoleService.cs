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
    public class UserRoleService : Service<UserRole>, IUserRoleService
    {
        private readonly IUserRoleRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public UserRoleService(IUserRoleRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public override async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return  await this.repository.GetAllAsync(x => x.Status != (int)EnumUserRoleStatus.SuperAdmin);
        }
    }
}