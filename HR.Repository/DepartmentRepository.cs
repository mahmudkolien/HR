using HR.Entities;
using HR.Repository.Context;
using HR.Repository.Contracts;
using HR.Repository.Core;

namespace HR.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly HRDbContext dbContext;

        public DepartmentRepository(HRDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}