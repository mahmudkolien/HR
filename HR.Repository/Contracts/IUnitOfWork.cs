using System.Threading.Tasks;

namespace HR.Repository.Contracts
{
    public interface IUnitOfWork
    {
          Task CompleteAsync();
    }
}