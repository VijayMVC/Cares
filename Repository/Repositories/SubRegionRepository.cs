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
    /// Sub Region Repository
    /// </summary>
    public sealed class SubRegionRepository : BaseRepository<SubRegion>, ISubRegionRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public SubRegionRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<SubRegion> DbSet
        {
            get
            {
                return db.SubRegions;
            }
        }

        #endregion
        #region Private
        /// <summary>
        /// Sub Region Orderby clause
        /// </summary>
        private readonly Dictionary<SubRegionByColumn, Func<SubRegion, object>> subRegionOrderByClause = new Dictionary<SubRegionByColumn, Func<SubRegion, object>>
                    {
                        {SubRegionByColumn.Code, d => d.GetHashCode()},
                        {SubRegionByColumn.Name, c => c.SubRegionName},
                        {SubRegionByColumn.Description, d => d.SubRegionDescription},
                        {SubRegionByColumn.Region, d => d.Region.RegionId},
                        
                    };
        #endregion
        #region Public
        /// <summary>
        /// Get All Sub Regions for User Domain Key
        /// </summary>
        public override IEnumerable<SubRegion> GetAll()
        {
            return DbSet.Where(subRegion => subRegion.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Find Sub Region By Id
        /// </summary>
        public SubRegion Find(int id)
        {
            return
                DbSet.Find(id);
        }

        /// <summary>
        /// Search Sub Region
        /// </summary>
        public IEnumerable<SubRegion> SearchSubRegion(SubRegionSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<SubRegion, bool>> query =
                subRegion =>
                    (string.IsNullOrEmpty(request.SubRegionFilterText) ||
                     (subRegion.SubRegionCode.Contains(request.SubRegionFilterText)) ||
                     (subRegion.SubRegionName.Contains(request.SubRegionFilterText))) && (
                         (!request.RegionId.HasValue || request.RegionId == subRegion.RegionId));

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(subRegionOrderByClause[request.SubRegionOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(subRegionOrderByClause[request.SubRegionOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// To check the association of region and sub region
        /// </summary>
        public bool IsRegionAssocistedWithSubRegion(long regionId)
        {
            return DbSet.Count(subRegion => subRegion.UserDomainKey == UserDomainKey && subRegion.RegionId == regionId) > 0;
        }

        /// <summary>
        /// Sub Region code duplication check
        /// </summary>
        public bool DoesSubRegionCodeExist(SubRegion subRegion)
        {
            return (DbSet.Count(dbsubRegion => dbsubRegion.SubRegionId != subRegion.SubRegionId && dbsubRegion.SubRegionCode == subRegion.SubRegionCode) > 0);
        }

        /// <summary>
        /// Get Sub Region with detailby id
        /// </summary>
        public SubRegion LoadSubRegionWithDetail(long subRegionId)
        {
            return DbSet.Include(region => region.Region)
               .FirstOrDefault(dbSubRegion => dbSubRegion.UserDomainKey == UserDomainKey && dbSubRegion.SubRegionId == subRegionId);
        }
        #endregion
    }
}
