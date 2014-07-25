﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Interfaces.Repository;
using Microsoft.Practices.Unity;
using Models.DomainModels;
using Models.RequestModels;
using Repository.BaseRepository;

namespace Repository.Repositories
{
    /// <summary>
    /// FleetPool Repository
    /// </summary>
    public sealed class FleetPoolRepository : BaseRepository<FleetPool>, IFleetPoolRepository
    {
        #region Public

        /// <summary>
        /// SearchFleet Pool for the given parameters by user
        /// </summary>
        public IEnumerable<FleetPool> SearchFleetPool(FleetPoolSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;

            rowCount =
                DbSet.Count(
                    fleet =>
                        (string.IsNullOrEmpty(request.FleetPoolCode) || fleet.FleetPoolCode.Contains(request.FleetPoolCode) ||fleet.FleetPoolName.Contains(request.FleetPoolCode))
                         && (!request.RegionId.HasValue || fleet.RegionId == request.RegionId.Value)
                         && (!request.OperationId.HasValue || fleet.OperationId == request.OperationId.Value));

            return DbSet.Where(fleet =>
                (string.IsNullOrEmpty(request.FleetPoolCode) ||
                 fleet.FleetPoolCode.Contains(request.FleetPoolCode) ||
                 fleet.FleetPoolName.Contains(request.FleetPoolCode))
                && (!request.RegionId.HasValue || fleet.RegionId == request.RegionId.Value)
                && (!request.OperationId.HasValue || fleet.OperationId == request.OperationId.Value)).OrderBy(x=>x.FleetPoolCode).Skip(fromRow).Take(toRow).ToList();
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
