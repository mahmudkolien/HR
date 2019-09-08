using System.Threading.Tasks;
using HR.Entities;
using HR.Repository.Core;

namespace HR.Repository.Contracts
{
    public interface IAuthenticationRepository : IRepository<User>
    {
        Task<User> GetByUserNameAsync(string userName, bool includeRelated = false);
    }
}