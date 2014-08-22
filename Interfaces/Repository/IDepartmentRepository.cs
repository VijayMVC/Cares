using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Department Repository Interface
    /// </summary>
    public interface IDepartmentRepository : IBaseRepository<Department, long>
    {
        List<string> GetDepartmentsTypes();
        IEnumerable<Department> SearchDepartment(DepartmentSearchRequest request, out int rowCount);
        Department GetDepartmentWithDetails(long id);

    }
}
