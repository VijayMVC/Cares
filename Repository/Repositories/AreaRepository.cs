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
    /// Area Repository
    /// </summary>
    public sealed class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        #region privte
        /// <summary>
        /// Area Orderby clause
        /// </summary>
        private readonly Dictionary<AreaByColumn, Func<Area, object>> areaOrderByClause = new Dictionary<AreaByColumn, Func<Area, object>>
                    {
                        {AreaByColumn.Code, d => d.AreaCode},
                        {AreaByColumn.Name, c => c.AreaName},
                        {AreaByColumn.Description, d => d.AreaDescription},
                        {AreaByColumn.City, d => d.City.CityId},
                        
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AreaRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Area> DbSet
        {
            get
            {
                return db.Areas;
            }
        }

        #endregion
        #region Public
        /// <summary>
        /// Get All Areas for User Domain Key
        /// </summary>
        public override IEnumerable<Area> GetAll()
        {
            return DbSet.Where(area => area.UserDomainKey == UserDomainKey).ToList();
        }


        /// <summary>
        /// Find Area By Id
        /// </summary>
        public Area Find(int id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// To check the association of area and city
        /// </summary>
        public bool IsCityAssociatedWithArea(long citId)
        {
            return DbSet.Count(area => area.UserDomainKey == UserDomainKey && area.CityId == citId) > 0;
        }

        /// <summary>
        /// Search Area
        /// </summary>
        public IEnumerable<Area> SearchArea(AreaSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<Area, bool>> query =
                area =>
                    (string.IsNullOrEmpty(request.AreaFilterText) ||
                     (area.AreaCode.Contains(request.AreaFilterText)) ||
                     (area.AreaName.Contains(request.AreaFilterText))) && (
                         (!request.CityId.HasValue || request.CityId == area.CityId)) && (area.UserDomainKey == UserDomainKey);

            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(areaOrderByClause[request.AreaOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(areaOrderByClause[request.AreaOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// To validte the code duplication check
        /// </summary>
        public bool DoesAreaCodeExist(Area area)
        {
            return DbSet.Count(dBarea => dBarea.AreaId != area.AreaId && dBarea.UserDomainKey == UserDomainKey  && dBarea.AreaCode == area.AreaCode) > 0;  
        }


        /// <summary> 
        /// Load detail instence of area
        /// </summary>
        public Area LoadAreaWithDetail(long areaId)
        {
            return DbSet.Include(area => area.City)
               .FirstOrDefault(area => area.UserDomainKey == UserDomainKey && area.AreaId == areaId);
            
        }
        #endregion
    }
}
