using System.Collections.Generic;
using System.Threading.Tasks;
using HR.Entities;
using HR.Repository.Context;
using HR.Repository.Contracts;
using HR.Repository.Core;

namespace HR.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly HRDbContext dbContext;

        public UserRepository(HRDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}