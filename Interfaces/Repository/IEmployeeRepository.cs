using System.Linq;
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
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        EmployeeSearchResponse GetAllEmployees(EmployeeSearchRequest searchRequest);

        /// <summary>
        /// Get Employee By Name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetEmployeeByName(string name, int id);
    }
}
