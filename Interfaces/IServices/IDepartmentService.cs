using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Department Service Interface
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// Get All Departments
        /// </summary>
        IEnumerable<Department> LoadAll();

        DepartmentBaseDataResponse LoadDepartmentBaseData();

        DepartmentSearchRequestResponse SearchDepartment(DepartmentSearchRequest request);
        void DeleteDepartment(Department department);
        Department SaveUpdateDepartment(Department request);



    }
}
