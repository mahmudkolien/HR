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

        public UserRoleService(IRepository<UserRole> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            
        }

        public UserRoleService(IUserRoleRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
    }
}