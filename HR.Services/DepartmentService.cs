using HR.Entities;
using HR.Repository;
using HR.Repository.Contracts;
using HR.Repository.Core;
using HR.Services.Contracts;
using HR.Services.Core;

namespace HR.Services
{
    public class DepartmentService : Service<Department>, IDepartmentService
    {
        private readonly IDepartmentRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public DepartmentService(IRepository<Department> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            
        }

        public DepartmentService(IDepartmentRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
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