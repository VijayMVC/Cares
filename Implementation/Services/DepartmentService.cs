using System.Collections.Generic;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;

namespace Implementation.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository iRepository;

          public DepartmentService(IDepartmentRepository xRepository)
        {
            iRepository = xRepository;
        }

        public IEnumerable<Department> LoadAll()
        {
            return iRepository.GetAll();
        }
    }
}
