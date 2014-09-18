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
    /// Employee Status Repository 
    /// </summary>
    public sealed class EmpStatusRepository : BaseRepository<EmpStatus>, IEmpStatusRepository
    {
        #region privte
        /// <summary>
        /// Employee Status Orderby clause
        /// </summary>
        private readonly Dictionary<EmpStatusByColumn, Func<EmpStatus, object>> empStatusOrderByClause = new Dictionary<EmpStatusByColumn, Func<EmpStatus, object>>
                    {
                        {EmpStatusByColumn.Code, d => d.EmpStatusCode},
                        {EmpStatusByColumn.Name, c => c.EmpStatusName}
                        
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public EmpStatusRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<EmpStatus> DbSet
        {
            get
            {
                return db.EmpStatuses;
            }
        }
        #endregion
        #region Public

        /// <summary>
        /// Get Employee Status for User Domain Key
        /// </summary>
        public override IEnumerable<EmpStatus> GetAll()
        {
            return DbSet.Where(empStatus => empStatus.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Search Employee status
        /// </summary>
        public IEnumerable<EmpStatus> SearchEmpStatus(EmpSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<EmpStatus, bool>> query =
                empStatus =>
                    (string.IsNullOrEmpty(request.EmpFilterText) ||
                     (empStatus.EmpStatusCode.Contains(request.EmpFilterText)) ||
                     (empStatus.EmpStatusName.Contains(request.EmpFilterText))) ;

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(empStatusOrderByClause[request.EmpStatusOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(empStatusOrderByClause[request.EmpStatusOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Employee status code duplication check
        /// </summary>
        public bool DoesEmpStatusCodeExist(EmpStatus empStatus)
        {
            return
                DbSet.Count(
                    dbempStatus =>
                        dbempStatus.EmpStatusId != empStatus.EmpStatusId &&
                        dbempStatus.EmpStatusCode == empStatus.EmpStatusCode) > 0;
        }
        #endregion
    }
}
