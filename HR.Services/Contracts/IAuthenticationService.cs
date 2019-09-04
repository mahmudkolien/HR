using System.Threading.Tasks;
using HR.Entities;
using HR.Entities.NotMapped;
using HR.Services.Core;

namespace HR.Services.Contracts
{
    public interface IAuthenticationService : IService<User>
    {
        Task<bool> IsValidUser(string userName, string password);
        Task<User> GetByUserNameAsync(string userName);
    }
}