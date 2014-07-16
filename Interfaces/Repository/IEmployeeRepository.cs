using System.Linq;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;
namespace Interfaces.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee, long>
    {
        EmployeeResponse GetAllEmployees(EmployeeSearchRequest searchRequest);
        IQueryable<Employee> GetEmployeesByDepartment(int depId);
        Employee GetEmployeeByName(string name, int id);
    }
}
