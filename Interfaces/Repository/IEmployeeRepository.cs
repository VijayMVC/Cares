using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Employee Repository Interface
    /// </summary>
    public interface IEmployeeRepository : IBaseRepository<Employee, long>
    {
        /// <summary>
        /// Get All Employees
        /// </summary>
        EmployeeSearchResponse GetAllEmployees(EmployeeSearchRequest searchRequest);

        /// <summary>
        /// Get Employee By Name
        /// </summary>
        Employee GetEmployeeByName(string name, int id);

        /// <summary>
        /// To check the association of employee with employee status
        /// </summary>
        bool IsEmployeeAssociatedWithEmployeeStatus(long empStatusId);

        /// <summary>
        /// Get All Chauffers - Used in Ra
        /// </summary>
        IEnumerable<Employee> GetAllChauffers(GetRaChaufferRequest request);

    }
}
