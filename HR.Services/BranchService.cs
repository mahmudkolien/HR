using System.Threading.Tasks;
using HR.Entities;
using HR.Entities.NotMapped;
using HR.Repository;
using HR.Repository.Contracts;
using HR.Repository.Core;
using HR.Services.Contracts;
using HR.Services.Core;

namespace HR.Services
{
    public class BranchService : Service<Branch>, IBranchService
    {
        private readonly IBranchRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public BranchService(IRepository<Branch> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            
        }

        public BranchService(IBranchRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public override async Task<QueryResult<Branch>> GetAllAsync()
        {
            return await this.repository.GetAllAsync(x => !x.IsDeleted);
        }
    }
}