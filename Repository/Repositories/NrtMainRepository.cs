using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Nr tMain Repository 
    /// </summary>
    public class NrtMainRepository : BaseRepository<NrtMain>, INrtMainRepository
    {
        #region Private
        private readonly Dictionary<NrtQueueByColumn, Func<NrtMain, object>> nRtMainClause =
             new Dictionary<NrtQueueByColumn, Func<NrtMain, object>>
                    {
                        { NrtQueueByColumn.NrtMainId, c => c.NrtMainId },
                        { NrtQueueByColumn.StartDate, c => c.StartDtTime },
                        { NrtQueueByColumn.EndDate, c => c.EndDtTime },
                        { NrtQueueByColumn.OpenLocation, c => c.OpenLocation },
                        { NrtQueueByColumn.CloseLocation, c => c.CloseLocation },
                        { NrtQueueByColumn.NrtTypeId, c => c.NrtTypeId },
                        { NrtQueueByColumn.Status, c => c.NrtStatusId },
                          };
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public NrtMainRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<NrtMain> DbSet
        {
            get
            {
                return db.NrtMain;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Associaton check with nrt type before deletion
        /// </summary>
        public bool IsNrtMainAssociatedWithNrtType(long nrtTypeId)
        {
            return DbSet.Count(nrtmain => nrtmain.NrtTypeId == nrtTypeId) > 0;
        }

        /// <summary>
        /// Get all NRT Main
        /// </summary>
        public NrtQueueSearchResponse GetNrtMainsForNrtQueue(NrtQueueSearchRequest request)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<NrtMain, bool>> query =
                s => (!request.NrtNumber.HasValue || s.NrtMainId == request.NrtNumber) && (!request.CloseLocationId.HasValue || s.CloseLocationId == request.CloseLocationId)
                     && (!request.OpenLocationId.HasValue || s.OpenLocationId == request.OpenLocationId) && (!request.StartDate.HasValue || DbFunctions.TruncateTime(s.StartDtTime) == DbFunctions.TruncateTime(request.StartDate))
                     && (!request.EndDate.HasValue || DbFunctions.TruncateTime(s.EndDtTime) == DbFunctions.TruncateTime(request.EndDate)) && (!request.NrtStatusId.HasValue || s.NrtStatusId == request.NrtStatusId)
                     && (!request.NrtTypeId.HasValue || s.NrtTypeId == request.NrtTypeId);

            IEnumerable<NrtMain> nRtMains = request.IsAsc ? DbSet.Where(query)
                                            .OrderBy(nRtMainClause[request.NrtQueueOrderBy]).Skip(fromRow).Take(toRow).ToList()
                                            : DbSet.Where(query)
                                                .OrderByDescending(nRtMainClause[request.NrtQueueOrderBy]).Skip(fromRow).Take(toRow).ToList();


            return new NrtQueueSearchResponse { NrtMains = nRtMains, TotalCount = DbSet.Count(query) };
        }

        #endregion
    }
}
