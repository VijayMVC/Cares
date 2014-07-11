using System.Collections.Generic;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Interfaces.IServices
{
    public interface IEmployeeService
    {
        EmployeeResponse LoadAll(EmployeeSearchRequest searchRequest);
        Employee Find(int id);
        IEnumerable<Employee> FindByDepartment(int depId);
        void Delete(Employee employee);
        bool Add(Employee employee);
        bool Update(Employee employee);
    }
}
