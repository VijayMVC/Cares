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
    /// Business Segment Repository
    /// </summary>
    public sealed class BusinessSegmentRepository : BaseRepository<BusinessSegment>, IBusinessSegmentRepository
    {
        #region Private
        /// <summary>
        /// Business Segment Orderby clause
        /// </summary>
        private readonly Dictionary<BusinessSegmentByColumn, Func<BusinessSegment, object>> businessSegmentOrderByClause = new Dictionary<BusinessSegmentByColumn, Func<BusinessSegment, object>>
                    {
                        {BusinessSegmentByColumn.BusinessSegmentCode, c => c.BusinessSegmentCode},
                        {BusinessSegmentByColumn.BusinessSegmentName, n => n.BusinessSegmentName},
                        {BusinessSegmentByColumn.BusinessSegmentDescription, d=> d.BusinessSegmentDescription},
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessSegmentRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<BusinessSegment> DbSet
        {
            get
            {
                return db.BusinessSegments;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Get All Business Segments for User Domain Key
        /// </summary>
        public override IEnumerable<BusinessSegment> GetAll()
        {
            return DbSet.Where(businessSegment => businessSegment.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Search Business Segment
        /// </summary>
        public IEnumerable<BusinessSegment> SearchBusinessSegment(BusinessSegmentSearchRequest businessSegmentSearchRequest,
            out int rowCount)
        {

            int fromRow = (businessSegmentSearchRequest.PageNo - 1) * businessSegmentSearchRequest.PageSize;
            int toRow = businessSegmentSearchRequest.PageSize;
            Expression<Func<BusinessSegment, bool>> query =
                businessSeg =>
                    (string.IsNullOrEmpty(businessSegmentSearchRequest.BusinessSegmentFilterText) ||
                     (businessSeg.BusinessSegmentCode.Contains(businessSegmentSearchRequest.BusinessSegmentFilterText)) ||
                     (businessSeg.BusinessSegmentName.Contains(businessSegmentSearchRequest.BusinessSegmentFilterText))) && (businessSeg.UserDomainKey == UserDomainKey);

            rowCount = DbSet.Count(query);
            return businessSegmentSearchRequest.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(businessSegmentOrderByClause[businessSegmentSearchRequest.BusinessSegmentOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(businessSegmentOrderByClause[businessSegmentSearchRequest.BusinessSegmentOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }


        /// <summary>
        ///  Business Segment Code validation check
        /// </summary>
        public bool IsBusinessSegmentCodeExists(BusinessSegment businessSegment)
        {
            return DbSet.Count(dbbusinessSegment=> dbbusinessSegment.BusinessSegmentCode.ToLower() == businessSegment.BusinessSegmentCode.ToLower() && dbbusinessSegment.BusinessSegmentId != businessSegment.BusinessSegmentId) > 0;

        }
        #endregion

    }
}
