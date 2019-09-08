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
    public class AuthenticationService : Service<User>, IAuthenticationService
    {
        private readonly IAuthenticationRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public AuthenticationService(IAuthenticationRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<User> GetByUserNameAsync(string userName, bool includeRelated = false)
        {
            return await this.repository.GetByUserNameAsync(userName, includeRelated);
        }

        public async Task<bool> IsValidUser(string userName, string password)
        {
            var user = await this.repository.GetByUserNameAsync(userName);
            if (user==null)
                return false;
            var isValidUser = user.Password==password.ToHash();
            if(!isValidUser)
            {
                user.AccessFailedCount = (user.AccessFailedCount??0) + 1;
                await base.UpdateAsync(user);
                return false;
            }
            return true;
        }

        public async Task<bool> ChangePasswordByUserNameAsync(string userName, string newPassword)
        {
            var user = await this.repository.GetByUserNameAsync(userName);
            user.LastPassword = user.Password;
            user.Password = newPassword.ToHash();
            user.PasswordChangedCount = user.PasswordChangedCount??0 + 1;
            user.LastPassChangeDate = DateTime.Now;
            await base.UpdateAsync(user);
            return true;
        }
    }
}