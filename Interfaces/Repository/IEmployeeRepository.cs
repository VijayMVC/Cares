using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee, long>
    {
        EmployeeResponse GetAllEmployees(EmployeeSearchRequest searchRequest);
        IQueryable<Employee> GetEmployeesByDepartment(int depId);
        Employee GetEmployeeByName(string name, int id);
    }
}
