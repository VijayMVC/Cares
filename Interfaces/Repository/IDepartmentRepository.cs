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
        /// <summary>
        /// Get Departments Types
        /// </summary>
        List<string> GetDepartmentsTypes();

        /// <summary>
        /// SearchD epartment
        /// </summary>
        IEnumerable<Department> SearchDepartment(DepartmentSearchRequest request, out int rowCount);

        /// <summary>
        /// Get Department With Details
        /// </summary>
        Department GetDepartmentWithDetails(long id);

        bool IsDepartmentCodeExists(Department department);


    }
}
