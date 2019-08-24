using System.Threading.Tasks;
using HR.Repository.Context;
using HR.Repository.Contracts;

namespace HR.Repository
{
    public class CompanyUnitOfWork : IUnitOfWork
    {
        private readonly HRDbContext context;
        public CompanyUnitOfWork(HRDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CompleteAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}