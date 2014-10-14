using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Department Repository
    /// </summary>
    public sealed class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        
        #region privte
        /// <summary>
        /// Department Orderby clause
        /// </summary>
        private readonly Dictionary<DepartmentByColumn, Func<Department, object>> departmentOrderByClause = new Dictionary<DepartmentByColumn, Func<Department, object>>
                    {

                        {DepartmentByColumn.DepartmentCode, c => c.DepartmentCode},
                        {DepartmentByColumn.DepartmentName, n => n.DepartmentName},
                        {DepartmentByColumn.DepartmentDescription, d=> d.DepartmentDescription},
                        {DepartmentByColumn.Company, c => c.Company.CompanyId},
                        {DepartmentByColumn.DepartmentType, c => c.DepartmentType},
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Department Constructor
        /// </summary>
        public DepartmentRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Department> DbSet
        {
            get
            {
                return db.Departments;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Departments for User Domain Key
        /// </summary>
        public override IEnumerable<Department> GetAll()
        {
            return DbSet.Where(department => department.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get Departments Types
        /// </summary>
        public List<string> GetDepartmentsTypes()
        {
            IQueryable<Department> departments = DbSet.GroupBy(b => b.DepartmentType).Select(b => b.FirstOrDefault());
            return departments.Select(dept => dept.DepartmentType).ToList();
        }

        /// <summary>
        /// Search Department
        /// </summary>
       public IEnumerable<Department> SearchDepartment(DepartmentSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize; 
            Expression<Func<Department, bool>> query =
                department =>
                    (string.IsNullOrEmpty(request.DepartmentFilterText) ||
                     (department.DepartmentCode.Contains(request.DepartmentFilterText)) ||
                     (department.DepartmentName.Contains(request.DepartmentFilterText)))  &&
                    (string.IsNullOrEmpty(request.DepartmentTypeText) ||
                     (department.DepartmentType.Contains(request.DepartmentTypeText))) &&
                    (!request.CompanyId.HasValue || request.CompanyId == department.CompanyId);
            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(departmentOrderByClause[request.OperationOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(departmentOrderByClause[request.OperationOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Get Department With Details
        /// </summary>
       public Department GetDepartmentWithDetails(long departmentId)
        {
            return DbSet.Include(opp => opp.Company)
                .FirstOrDefault(opp => opp.DepartmentId == departmentId);
        }

        /// <summary>
        /// Department Code validation check
        /// </summary>
       public bool IsDepartmentCodeExists(Department dep)
        {
            return DbSet.Count(department => department.DepartmentCode.ToLower() == dep.DepartmentCode.ToLower() &&
            department.DepartmentId != dep.DepartmentId) > 0;
        }

        /// <summary>
        /// To check either company have any department
        /// </summary>
        public bool IsCompanyContainDepartment(long companyId)
        {
            return DbSet.Count(department => department.CompanyId == companyId) > 0;
        }
        #endregion
    }
}
