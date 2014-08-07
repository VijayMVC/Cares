using System.Collections.Generic;
using Cares.Models.DomainModels;

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
    }
}
