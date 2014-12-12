using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.CommonTypes;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Operation Repository
    /// </summary>
    public sealed class OperationRepository : BaseRepository<Operation>, IOperationRepository
    {
        #region privte
        /// <summary>
        /// Company Orderby clause
        /// </summary>
        private readonly Dictionary<OperationByColumn, Func<Operation, object>> operationOrderByClause = new Dictionary<OperationByColumn, Func<Operation, object>>
                    {

                        {OperationByColumn.OperationCode, c => c.OperationName},
                        {OperationByColumn.OperationName, n => n.OperationName},
                        {OperationByColumn.Description, d=> d.OperationDescription},
                        {OperationByColumn.Department,d=> d.Department.DepartmentName},
                        {OperationByColumn.Company, c => c.Department.Company.CompanyName},
                        {OperationByColumn.DepartmentType, c => c.Department.DepartmentType},
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public OperationRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Operation> DbSet
        {
            get
            {
                return db.Operations;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Get all Operations
        /// </summary>
        public override IEnumerable<Operation> GetAll()
        {
            return DbSet.Where(operation => operation.UserDomainKey == UserDomainKey ).ToList();
        }

        /// <summary>
        /// Get All SalesOperation
        /// </summary>
        public ICollection<Operation> GetSalesOperation()
        {
            return DbSet.Include(operation => operation.Department).Where(operation => operation.UserDomainKey==UserDomainKey && operation.Department.DepartmentType == DepartmentTypes.Sales).ToList();
        }

        /// <summary>
        /// SearchO peration
        /// </summary>
        public IEnumerable<Operation> SearchOperation(OperationSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<Operation, bool>> query =
                operation =>
                    (string.IsNullOrEmpty(request.OperationFilterText) ||
                     (operation.OperationCode.Contains(request.OperationFilterText)) ||
                     (operation.OperationName.Contains(request.OperationFilterText))) &&
                    (string.IsNullOrEmpty(request.DepartmentTypeText) ||
                     (operation.Department.DepartmentType.Contains(request.DepartmentTypeText))) && operation.UserDomainKey==UserDomainKey;

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(operationOrderByClause[request.OperationOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(operationOrderByClause[request.OperationOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Get Operation With Details
        /// </summary>
        public Operation GetOperationWithDetails(long id)
        {
            return DbSet.Include(opp => opp.Department)
                .FirstOrDefault(opp => opp.OperationId == id && opp.UserDomainKey == UserDomainKey);
        }

        /// <summary>
        /// Operation Code validation
        /// </summary>
        public bool IsOperationCodeExists(Operation operation)
        {
            return DbSet.Count(opp =>opp.UserDomainKey==UserDomainKey &&  opp.OperationCode==operation.OperationCode && opp.OperationId != operation.OperationId) > 0;
        }

        /// <summary>
        /// To check if department is associated with any operation
        /// </summary>
        public bool IsDepartmentAssociatedWithAnyOperation(long departmentId)
        {
            return DbSet.Count(opp => opp.DepartmentId == departmentId && opp.UserDomainKey == UserDomainKey) > 0;
        }

        #endregion
    }
}
