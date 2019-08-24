using HR.Entities;
using HR.Services.Core;

namespace HR.Services.Contracts
{
    public interface IDepartmentService : IService<Department>
    {
         void CompleteAsync();
    }
}