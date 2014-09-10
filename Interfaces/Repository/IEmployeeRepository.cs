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
        EmployeeResponse GetAllEmployees(EmployeeSearchRequest searchRequest);

        /// <summary>
        /// Get Employees By Department
        /// </summary>
        /// <param name="depId"></param>
        /// <returns></returns>
        IQueryable<Employee> GetEmployeesByDepartment(int depId);
        
        /// <summary>
        /// Get Employee By Name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee GetEmployeeByName(string name, int id);
    }
}
