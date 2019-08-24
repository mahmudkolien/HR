using HR.Entities;
using HR.Repository;
using HR.Repository.Contracts;
using HR.Repository.Core;
using HR.Services.Contracts;
using HR.Services.Core;

namespace HR.Services
{
    public class CompanyService : Service<Company>, ICompanyService
    {
        private readonly ICompanyRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public CompanyService(IRepository<Company> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            
        }

        public CompanyService(ICompanyRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
        public void CompleteAsync()
        {
            this.unitOfWork.CompleteAsync();
            
        }
      
        
    }
}