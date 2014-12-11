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
    /// Vehicle Status Repository
    /// </summary>
    public sealed class VehicleStatusRepository : BaseRepository<VehicleStatus>, IVehicleStatusRepository 
    {
        #region privte
        /// <summary>
        /// Vehicle Status Orderby clause
        /// </summary>
        private readonly Dictionary<VehicleStatusByColumn, Func<VehicleStatus, object>> vehicleStatusOrderByClause = new Dictionary<VehicleStatusByColumn, Func<VehicleStatus, object>>
                    {

                        {VehicleStatusByColumn.Code, c => c.VehicleStatusCode},
                        {VehicleStatusByColumn.Name, n => n.VehicleStatusName}
                    };
        #endregion
        #region Constructor
        /// <summary>
        /// Vehicle Status Repository Constructor
        /// </summary>
        public VehicleStatusRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<VehicleStatus> DbSet
        {
            get
            {
                return db.VehicleStatuses;
            }
        }

        #endregion
        #region Public

        /// <summary>
        /// Get All Vehicle Status for User Domain Key
        /// </summary>
        public override IEnumerable<VehicleStatus> GetAll()
        {
            return DbSet.Where(vs => vs.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// SearchD Vehicle Statuse
        /// </summary>
        public IEnumerable<VehicleStatus> SearchVehicleStatus(VehicleStatusSearchRequest request, out int rowCount)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<VehicleStatus, bool>> query =
                vehicleStatus =>
                    (string.IsNullOrEmpty(request.VehicleStatusCodeNameFilterText) ||
                     (vehicleStatus.VehicleStatusCode.Contains(request.VehicleStatusCodeNameFilterText)) ||
                     (vehicleStatus.VehicleStatusName.Contains(request.VehicleStatusCodeNameFilterText))) && (vehicleStatus.UserDomainKey == UserDomainKey);
            rowCount = DbSet.Count(query);
            return request.IsAsc
                ? DbSet.Where(query)
                    .OrderBy(vehicleStatusOrderByClause[request.VehicleStatusOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList()
                : DbSet.Where(query)
                    .OrderByDescending(vehicleStatusOrderByClause[request.VehicleStatusOrderBy])
                    .Skip(fromRow)
                    .Take(toRow)
                    .ToList();
        }

        /// <summary>
        /// Vehicle Status Self code duplication check
        /// </summary>
        public bool VehicleStatusCodeDuplicationCheck(VehicleStatus vehicleStatus)
        {
            return
                DbSet.Count(
                    dbvehicleStatus =>
                        dbvehicleStatus.VehicleStatusCode == vehicleStatus.VehicleStatusCode &&
                        dbvehicleStatus.VehicleStatusId != vehicleStatus.VehicleStatusId) > 0;
        }
        #endregion
    }
}
