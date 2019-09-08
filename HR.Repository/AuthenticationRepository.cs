using System;
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

        public async Task<User> GetByUserNameAsync(string userName, bool includeRelated = false)
        {
            var query = this.dbContext.Users.AsQueryable();
            if(includeRelated)
                query = query.Include(y => y.UserRole).ThenInclude(p => p.UserRolePermissions);
            return await query.AsNoTracking().FirstOrDefaultAsync(x => x.UserName.ToLower()==userName.ToLower());
        }
    }
}