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
    /// Region Repository
    /// </summary>
    public sealed class RegionRepository : BaseRepository<Region>, IRegionRepository
    {
        #region privte
        /// <summary>
        /// Region Orderby clause
        /// </summary>
        private readonly Dictionary<RegionByColumn, Func<Region, object>> regionOrderByClause = new Dictionary<RegionByColumn, Func<Region, object>>
                    {
                        {RegionByColumn.RegionCode, d => d.RegionCode},
                        {RegionByColumn.RegionName, c => c.RegionName},
                        {RegionByColumn.RegiontDescription, d => d.RegionDescription},
                        {RegionByColumn.Country, d => d.Country.CountryId},
                        
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public RegionRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Region> DbSet
        {
            get
            {
                return db.Regions;
            }
        }
        #endregion
        #region Public
        /// <summary>
        /// Get All Measurement Units for User Domain Key
        /// </summary>
        public override IEnumerable<Region> GetAll()
        {
            return DbSet.Where(region => region.UserDomainKey == UserDomainKey).ToList();
        }

        public IEnumerable<Region> GetRegions(int id)
        {
            return DbSet.Where(region => region.CountryId == id);
        }

        /// <summary>
        /// Get Regions by Country Id
        /// </summary>
        public IEnumerable<Region> GetRegionsByCountry(int countryId)
        {
            return DbSet.Where(region => region.CountryId == countryId);
        }

        /// <summary>
        /// Search Region
        /// </summary>
        public IEnumerable<Region> SearchRegion(RegionSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<Region, bool>> query =
                region =>
                    (string.IsNullOrEmpty(request.RegionFilterText) ||
                     (region.RegionCode.Contains(request.RegionFilterText)) ||
                     (region.RegionName.Contains(request.RegionFilterText))) && (
                         (!request.CountryId.HasValue || request.CountryId == region.CountryId));

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(regionOrderByClause[request.RegionOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(regionOrderByClause[request.RegionOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Find Region
        /// </summary>
        public Region Find(int id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Region code duplication check
        /// </summary>
        public bool DoesRegionCodeExist(Region region)
        {
          return  (DbSet.Count(dbregion => dbregion.RegionId != region.RegionId && dbregion.RegionCode == region.RegionCode)>0);
        }


        /// <summary>
        /// Get Region with detail
        /// </summary>
        public Region LoadRegionWithDetail(long regionId)
        {
            return DbSet.Include(region => region.Country)
               .FirstOrDefault(region => region.UserDomainKey == UserDomainKey && region.RegionId == regionId);
        }
        #endregion
    }
}
