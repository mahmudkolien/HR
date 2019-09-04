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

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await this.repository.GetByUserNameAsync(userName);
        }

        public async Task<bool> IsValidUser(string userName, string password)
        {
            return await this.repository.IsValidUser(userName, password);
        }
    }
}