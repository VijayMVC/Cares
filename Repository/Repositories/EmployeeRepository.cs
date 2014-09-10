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
                        { EmployeeByColumn.Name, c => c.Name },
                        { EmployeeByColumn.DepartmentName, c => c.Department }
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
        public EmployeeResponse GetAllEmployees(EmployeeSearchRequest searchRequest)
        {
            int fromRow = (searchRequest.PageNo - 1) * searchRequest.PageSize;
            int toRow = searchRequest.PageSize;

            Expression<Func<Employee, bool>> query =
                s => (!searchRequest.DepartmentId.HasValue || s.DepartmentId == searchRequest.DepartmentId) &&
                     (string.IsNullOrEmpty(searchRequest.SearchString) || s.Name.Contains(searchRequest.SearchString));

            IEnumerable<Employee> employees = searchRequest.IsAsc ? DbSet.Where(query).Include("Department")
                                            .OrderBy(employeeClause[searchRequest.EmployeeOrderBy]).Skip(fromRow).Take(toRow).ToList()
                                            : DbSet.Where(query).Include("Department")
                                                .OrderByDescending(employeeClause[searchRequest.EmployeeOrderBy]).Skip(fromRow).Take(toRow).ToList();

            return new EmployeeResponse { Employees = employees, TotalCount = DbSet.Count(query) };
        }

        public Employee GetEmployeeByName(string name, int id)
        {
            return DbSet.FirstOrDefault(x => x.Name == name && x.Id != id);
        }

        public IQueryable<Employee> GetEmployeesByDepartment(int Id)
        {
            return DbSet.Where(x => x.DepartmentId == Id).AsQueryable();
        }
        /// <summary>
        /// Get All Employees for User Domain Key
        /// </summary>
        public override IEnumerable<Employee> GetAll()
        {
            return DbSet.Where(employee => employee.UserDomainKey == UserDomainKey).ToList();
        }
        #endregion
    }
}
