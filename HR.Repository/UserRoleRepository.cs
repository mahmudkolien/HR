using HR.Entities;
using HR.Repository.Context;
using HR.Repository.Contracts;
using HR.Repository.Core;

namespace HR.Repository
{
    public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
    {
        private readonly HRDbContext dbContext;

        public UserRoleRepository(HRDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}