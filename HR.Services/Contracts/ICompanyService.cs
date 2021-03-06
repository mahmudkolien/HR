using HR.Entities;
using HR.Services.Core;

namespace HR.Services.Contracts
{
    public interface ICompanyService : IService<Company>
    {
         void CompleteAsync();
    }
}