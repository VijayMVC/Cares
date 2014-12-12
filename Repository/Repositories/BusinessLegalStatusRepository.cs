using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.RequestModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using Cares.Models.DomainModels;

namespace Cares.Repository.Repositories
{
    public sealed class BusinessLegalStatusRepository : BaseRepository<BusinessLegalStatus>, IBusinessLegalStatusRepository
    {
        #region privte
        /// <summary>
        /// Business Legal Status Orderby clause
        /// </summary>
        private readonly Dictionary<BusinessLegalStatusByColumn, Func<BusinessLegalStatus, object>> businessLegalStatusOrderByClause = new Dictionary<BusinessLegalStatusByColumn, Func<BusinessLegalStatus, object>>
                    {

                        {BusinessLegalStatusByColumn.Code, c => c.BusinessLegalStatusCode},
                        {BusinessLegalStatusByColumn.Name, n => n.BusinessLegalStatusName}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessLegalStatusRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessLegalStatus> DbSet
        {
            get
            {
                return db.BusinessLegalStatuses;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Get All Business Segments for User Domain Key
        /// </summary>
        public override IEnumerable<BusinessLegalStatus> GetAll()
        {
            return DbSet.Where(businessLegalStatus => businessLegalStatus.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Search Business Legal Status
        /// </summary>
       public IEnumerable<BusinessLegalStatus> SearchBusinessLegalStatus(BusinessLegalStatusSearchRequest request,
            out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<BusinessLegalStatus, bool>> query =
                businessLegalStatus =>
                    (string.IsNullOrEmpty(request.BusinessLegalStatusSearchText) ||
                     (businessLegalStatus.BusinessLegalStatusCode.Contains(request.BusinessLegalStatusSearchText)) ||
                     (businessLegalStatus.BusinessLegalStatusName.Contains(request.BusinessLegalStatusSearchText))) 
                     && (businessLegalStatus.UserDomainKey == UserDomainKey);
            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(businessLegalStatusOrderByClause[request.BusinessLegalStatusOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(businessLegalStatusOrderByClause[request.BusinessLegalStatusOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList(); 
        }

        /// <summary>
        /// Self-code duplication check
        /// </summary>
        public bool BusinessLegalStatusCodeDuplicationCheck(BusinessLegalStatus request)
        {
           return DbSet.Count(
                businessLegalStatus =>
                    businessLegalStatus.BusinessLegalStatusCode == request.BusinessLegalStatusCode &&
                    businessLegalStatus.BusinessLegalStatusId != request.BusinessLegalStatusId
                    && businessLegalStatus.UserDomainKey == UserDomainKey) > 0;
        }
        #endregion
    }
}
