using System.Collections.Generic;
using Models.DomainModels;

namespace Interfaces.Repository
{
    public interface IDepartmentRepository : IBaseRepository<Department, int>
    {
        IEnumerable<Department> GetAll();
    }
}
