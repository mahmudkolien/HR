using System.Threading.Tasks;
using HR.Repository.Context;
using HR.Repository.Contracts;

namespace HR.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRDbContext context;

        public UnitOfWork(HRDbContext context)
        {
        this.context = context;
        }

        public async Task<bool> CompleteAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}