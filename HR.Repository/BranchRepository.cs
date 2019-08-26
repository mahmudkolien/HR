using HR.Entities;
using HR.Repository.Context;
using HR.Repository.Contracts;
using HR.Repository.Core;

namespace HR.Repository
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        private readonly HRDbContext dbContext;

        public BranchRepository(HRDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}