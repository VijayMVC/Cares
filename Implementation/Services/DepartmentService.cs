using System.Collections.Generic;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Services
{
    public class DepartmentService : IDepartmentService
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