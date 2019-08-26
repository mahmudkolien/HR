using HR.Entities;
using HR.Repository.Context;
using HR.Repository.Contracts;
using HR.Repository.Core;

namespace HR.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly HRDbContext dbContext;

        public CompanyRepository(HRDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}