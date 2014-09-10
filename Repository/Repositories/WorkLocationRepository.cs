using System;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Work Location Repository
    /// </summary>
    public sealed class WorkLocationRepository : BaseRepository<WorkLocation>, IWorkLocationRepository
    {
        #region privte
        /// <summary>
        /// Work Location OrderByClause
        /// </summary>
        private readonly Dictionary<WorkLocationByColumn, Func<WorkLocation, object>> workLocationOrderByClause = new Dictionary<WorkLocationByColumn, Func<WorkLocation, object>>
                    {
                        {WorkLocationByColumn.WorkPlaceCode, c => c.WorkLocationCode},
                        {WorkLocationByColumn.WorkPlaceName, c => c.WorkLocationName},
                        {WorkLocationByColumn.Description, c => c.WorkLocationDescription},
                        {WorkLocationByColumn.Company, c => c.CompanyId},
                        {WorkLocationByColumn.Country, c => c.Address.CountryId},
                        {WorkLocationByColumn.Region, c => c.Address.RegionId},
                        {WorkLocationByColumn.SubRegion, c => c.Address.SubRegionId},
                        {WorkLocationByColumn.City, c => c.Address.SubRegionId},
                        {WorkLocationByColumn.Area, c => c.Address.AreaId},
                       
                    };
        #endregion
        
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WorkLocationRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<WorkLocation> DbSet
        {
            get
            {
                return db.WorkLocations;
            }
        }

        #endregion
        
        #region Public

        /// <summary>
        /// Get all WorkLocations
        /// </summary>
        public override IEnumerable<WorkLocation> GetAll()
        {
            return DbSet.Where(workLocation => workLocation.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Search Work Locations
        /// </summary>
        public IEnumerable<WorkLocation> SearchWorkLocation(WorkLocationSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;

            Expression<Func<WorkLocation, bool>> query =
                workLocation =>
                    (string.IsNullOrEmpty(request.WorkLocationCodeText) ||
                     (workLocation.WorkLocationCode.Contains(request.WorkLocationCodeText))) && (
                         (string.IsNullOrEmpty(request.WorkLocationNameText) ||
                          (workLocation.WorkLocationName.Contains(request.WorkLocationNameText)))) &&
                   
                    (!request.CompanyId.HasValue || request.CompanyId == workLocation.CompanyId) &&
                    (!request.CountryId.HasValue || request.CountryId == workLocation.Address.CountryId)
                    &&

                    (!request.RegionId.HasValue || request.RegionId == workLocation.Address.RegionId) &&
                    (!request.SubRegionId.HasValue || request.SubRegionId == workLocation.Address.SubRegionId)
                    &&

                    (!request.CityId.HasValue || request.CityId == workLocation.Address.CityId) &&
                    (!request.AreaId.HasValue || request.AreaId == workLocation.Address.AreaId)
                    ;


            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Include(wl => wl.Phones).Where(query)
                    .OrderBy(workLocationOrderByClause[request.WorkLocationOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Include(wl => wl.Phones).Where(query)
                    .OrderByDescending(workLocationOrderByClause[request.WorkLocationOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Get Work Location With Details
        /// </summary>
        public WorkLocation GetWorkLocationWithDetails(long workLocationId)
        {
            return DbSet.Include(opp => opp.Company)
                .Include(opp => opp.Address)
                .Include(opp => opp.Address.Country)
                .Include(opp => opp.Address.Region)
                .Include(opp => opp.Address.SubRegion)
                .Include(opp => opp.Address.City)
                .Include(opp => opp.Address.Area)
                .Include(opp => opp.Phones)
                .FirstOrDefault(workLocation => workLocation.WorkLocationId == workLocationId);
        }

        #endregion
    }
}
