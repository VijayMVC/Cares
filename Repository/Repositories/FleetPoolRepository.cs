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
    /// FleetPool Repository
    /// </summary>
    public sealed class FleetPoolRepository : BaseRepository<FleetPool>, IFleetPoolRepository
    {
        #region Private
        /// <summary>
        /// To sort the FleetPool Data
        /// </summary>
        private readonly Dictionary<FleetPoolByColumn, Func<FleetPool, object>> fleetPoolOrderByClause = new Dictionary<FleetPoolByColumn, Func<FleetPool, object>>
                    {
                        { FleetPoolByColumn.FleetPoolCode, c => c.FleetPoolCode },
                        { FleetPoolByColumn.FleetPoolName, c => c.FleetPoolName },
                        { FleetPoolByColumn.Operation, c=> c.OperationId},
                        { FleetPoolByColumn.Region, c=> c.RegionId}
                    };
        #endregion
        #region Public
        /// <summary>
        /// SearchFleet Pool for the given parameters by user
        /// </summary>
        public IEnumerable<FleetPool> SearchFleetPool(FleetPoolSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;

            Expression<Func<FleetPool, bool>> query =
                fleet =>
                        (string.IsNullOrEmpty(request.FleetPoolSearchText) || fleet.FleetPoolCode.Contains(request.FleetPoolSearchText) ||fleet.FleetPoolName.Contains(request.FleetPoolSearchText))
                         && (!request.RegionId.HasValue || fleet.RegionId == request.RegionId.Value)
                         && (!request.OperationId.HasValue || fleet.OperationId == request.OperationId.Value);

            rowCount = DbSet.Count(query);

            return request.IsAsc ? DbSet.Where(query).OrderBy(fleetPoolOrderByClause[request.FleetPoolOrderBy]).Skip(fromRow).Take(toRow).ToList() :
                                   DbSet.Where(query).OrderByDescending(fleetPoolOrderByClause[request.FleetPoolOrderBy]).Skip(fromRow).Take(toRow).ToList();
        }
        /// <summary>
        /// Find fleet pool with reference data
        /// </summary>
        public FleetPool GetFleetPoolWithDetails(long id)
        {
            return DbSet.Include(fleetPool => fleetPool.Operation)
                .Include(fleetPool => fleetPool.Region)
                .Include(fleetPool => fleetPool.Region.Country)
                .FirstOrDefault(fleetPool => fleetPool.UserDomainKey == UserDomainKey && fleetPool.FleetPoolId == id);
        }

        /// <summary>
        /// Fleet Pool  Code Check
        /// </summary>
        public bool IsFleetPoolCodeExists(FleetPool fleetPool)
        {
            Expression<Func<FleetPool, bool>> query = fleet => fleet.FleetPoolCode.Contains(fleetPool.FleetPoolCode) && fleet.FleetPoolId !=fleetPool.FleetPoolId;
            return DbSet.Count(query) > 0;
        }
        #endregion 
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FleetPoolRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<FleetPool> DbSet
        {
            get
            {
                return db.FleetPools;
            }
        }

        #endregion

    }
}
