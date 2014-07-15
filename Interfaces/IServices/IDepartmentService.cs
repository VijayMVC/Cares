using System.Collections.Generic;
using Models.DomainModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// Department Service Interface
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns></returns>
        IEnumerable<Department> LoadAll();
    }
}
