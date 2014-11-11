using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    public sealed class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        #region Private
        /// <summary>
        /// Order by Column Names Dictionary statements - for Employee
        /// </summary>
        private readonly Dictionary<EmployeeByColumn, Func<Employee, object>> employeeClause =
              new Dictionary<EmployeeByColumn, Func<Employee, object>>
                    {
                        { EmployeeByColumn.Code, c => c.EmpCode },
                        { EmployeeByColumn.FName, c => c.EmpFName },
                        { EmployeeByColumn.LName, c => c.EmpLName },
                        { EmployeeByColumn.Status, c => c.EmpStatus.EmpStatusId },
                        { EmployeeByColumn.Company, c => c.CompanyId },
                        { EmployeeByColumn.Nationality, c => c.NationalityId }
                    };
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Employee> DbSet
        {
            get
            {
                return db.Employees;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get All Employees
        /// </summary>
        public EmployeeSearchResponse GetAllEmployees(EmployeeSearchRequest searchRequest)
        {
            int fromRow = (searchRequest.PageNo - 1) * searchRequest.PageSize;
            int toRow = searchRequest.PageSize;

            Expression<Func<Employee, bool>> query =
                s => (!searchRequest.CompanyId.HasValue || s.Company.CompanyId == searchRequest.CompanyId) && (!searchRequest.EmployeeStatusId.HasValue || s.EmpStatus.EmpStatusId == searchRequest.EmployeeStatusId) &&
                     (string.IsNullOrEmpty(searchRequest.SearchString) || s.EmpCode.Contains(searchRequest.SearchString) || s.EmpFName.Contains(searchRequest.SearchString)
                     || s.EmpLName.Contains(searchRequest.SearchString) || s.EmpMName.Contains(searchRequest.SearchString));

            IEnumerable<Employee> employees = searchRequest.IsAsc ? DbSet.Where(query)
                                            .OrderBy(employeeClause[searchRequest.EmployeeOrderBy]).Skip(fromRow).Take(toRow).ToList()
                                            : DbSet.Where(query)
                                                .OrderByDescending(employeeClause[searchRequest.EmployeeOrderBy]).Skip(fromRow).Take(toRow).ToList();

            return new EmployeeSearchResponse { Employees = employees, TotalCount = DbSet.Count(query) };
        }

        /// <summary>
        /// Get Employee By Name
        /// </summary>
        public Employee GetEmployeeByName(string name, int id)
        {
            return DbSet.FirstOrDefault(x => x.EmpFName == name && x.EmployeeId != id);
        }

        /// <summary>
        /// Get All Employees for User Domain Key
        /// </summary>
        public override IEnumerable<Employee> GetAll()
        {
            return DbSet.Where(employee => employee.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Find Employee By Id
        /// </summary>
        public override Employee Find(long empId)
        {
            return
              DbSet.Include(emp => emp.Company)
                  .Include(emp => emp.EmpStatus)
                  .Include(emp => emp.Nationality)
                  .FirstOrDefault(emp => emp.EmployeeId == empId);
        }

        /// <summary>
        /// To check the association of employee with employee status
        /// </summary>
        public bool IsEmployeeAssociatedWithEmployeeStatus(long empStatusId)
        {
            return DbSet.Count(emp => emp.EmpStatusId == empStatusId) > 0;
        }

        /// <summary>
        /// Get All Chauffers
        /// </summary>
        public IEnumerable<Employee> GetAllChauffers(GetRaChaufferRequest request)
        {
            return DbSet
                .Include("EmpJobInfo")
                .Include("EmpJobInfo.WorkPlace.OperationsWorkPlaces")
                .Include("EmpJobInfo.Designation")
                .Include("EmpJobInfo.DesigGrade")
                .Where(
                    employee =>
                        employee.EmpJobInfo.WorkPlace.OperationsWorkPlaces.Any(
                            ow => ow.OperationsWorkPlaceId == request.OperationsWorkPlaceId) &&
                        employee.EmpJobInfo.Designation.DesignationKey == request.DesignationKey &&
            (employee.ChaufferReservations.Count == 0 ||
             !employee.ChaufferReservations.Any(
                 chaufferRes => chaufferRes.StartDtTime <= request.EndDtTime &&
                                chaufferRes.EndDtTime >= request.StartDtTime))).ToList();
        }

        /// <summary>
        /// Get Currently Logged In Employee
        /// </summary>
        public Employee GetEmployee()
        {
            return DbSet.FirstOrDefault(employee => employee.UserDomainKey == UserDomainKey);
        }

        #endregion
    }
}
