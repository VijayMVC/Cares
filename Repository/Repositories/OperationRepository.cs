using System;
using System.Collections;
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
        #region Public

        /// <summary>
        /// get all Operations
        /// </summary>
        public override IEnumerable<Operation> GetAll()
        {
            return DbSet.Where(operation => operation.UserDomainKey == UserDomainKey ).ToList();
        }

        /// <summary>
        /// GetSalesOperation
        /// </summary>
        public ICollection<Operation> GetSalesOperation()
        {
            return DbSet.Include(operation => operation.Department).Where(operation => operation.Department.DepartmentType == DepartmentTypes.Sales).ToList();
        }

        /// <summary>
        /// SearchOperation
        /// </summary>
        public IEnumerable<Operation> SearchOperation(OperationSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<Operation, bool>> query =
                operation =>
                    (string.IsNullOrEmpty(request.OperationCodeText) ||
                     (operation.OperationCode.Contains(request.OperationCodeText))) && (
                         (string.IsNullOrEmpty(request.OperationNameText) ||
                          (operation.OperationName.Contains(request.OperationNameText)))) &&
                    (string.IsNullOrEmpty(request.DepartmentTypeText) ||
                     (operation.Department.DepartmentType.Contains(request.DepartmentTypeText))) &&
                    (!request.DepartmentId.HasValue || request.DepartmentId == operation.DepartmentId) &&
                    (!request.CompanyId.HasValue || request.CompanyId == operation.Department.CompanyId);


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
        /// Get Company With Details
        /// </summary>
        public Operation GetCompanyWithDetails(long id)
        {
            return DbSet.Include(opp => opp.Department)
                .FirstOrDefault(opp => opp.OperationId == id);
        }
        #endregion
    }
}
