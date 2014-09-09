using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Employee Service Interface
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Load All Employee based on search criteria
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        EmployeeResponse LoadAll(EmployeeSearchRequest searchRequest);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Employee Find(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="depId"></param>
        /// <returns></returns>
        IEnumerable<Employee> FindByDepartment(int depId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        void Delete(Employee employee);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        bool Add(Employee employee);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        bool Update(Employee employee);

        /// <summary>
        /// Get Base Data
        /// </summary>
        /// <returns></returns>
        EmployeeBaseResponse GetBaseData();
    }
}
