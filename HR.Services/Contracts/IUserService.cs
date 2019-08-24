using System.Threading.Tasks;
using HR.Entities;
using HR.Entities.NotMapped;
using HR.Services.Core;

namespace HR.Services.Contracts
{
    public interface IUserService : IService<User>
    {
        Task<QueryResult<User>> GetAllAsync(UserQuery query);
    }
}