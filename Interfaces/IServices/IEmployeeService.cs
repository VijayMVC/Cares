using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
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
