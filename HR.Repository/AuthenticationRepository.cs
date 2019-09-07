using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Common;
using HR.Entities;
using HR.Repository.Context;
using HR.Repository.Contracts;
using HR.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace HR.Repository
{
    public class AuthenticationRepository : Repository<User>, IAuthenticationRepository
    {
        private readonly HRDbContext dbContext;

        public AuthenticationRepository(HRDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await this.dbContext.Users.Where(x => x.UserName==userName)
                                .Include(y => y.UserRole).ThenInclude(p => p.UserRolePermissions).FirstOrDefaultAsync();
        }

        public async Task<bool> IsValidUser(string userName, string password)
        {
            return await this.dbContext.Users.Where(x => x.UserName==userName && x.Password==password.ToHash())
                                .AnyAsync();
        }
    }
}