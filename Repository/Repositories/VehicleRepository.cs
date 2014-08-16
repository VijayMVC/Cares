using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Vehicle Repository
    /// </summary>
    public sealed class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        #region Private

        /// <summary>
        /// Vehicle Order By Clause
        /// </summary>
        private readonly Dictionary<VehicleOrderByColumn, Func<Vehicle, object>> vehicleOrderByClause =
             new Dictionary<VehicleOrderByColumn, Func<Vehicle, object>>
                    {
                        { VehicleOrderByColumn.PlateNumber, c => c.PlateNumber },
                        { VehicleOrderByColumn.CurrentOdometer, c => c.CurrentOdometer },
                        { VehicleOrderByColumn.VehicleCategory, c => c.VehicleCategory.VehicleCategoryName },
                        { VehicleOrderByColumn.VehicleMake, c => c.VehicleMake.VehicleMakeName },
                        { VehicleOrderByColumn.VehicleModel, c => c.VehicleModel.VehicleModelName },
                        { VehicleOrderByColumn.ModelYear, c => c.ModelYear }
                    };

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Vehicle> DbSet
        {
            get
            {
                return db.Vehicles;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public VehicleRepository(IUnityContainer container)
            : base(container)
        {

        }

        #endregion

        #region Public

        /// <summary>
        /// Get By Hire Group
        /// </summary>
        public GetVehicleResponse GetByHireGroup(VehicleSearchRequest request)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<Vehicle, bool>> query = vehicle => (vehicle.HireGroupId == request.HireGroupId);

            IEnumerable<Vehicle> vehicles = request.IsAsc ? DbSet
                .Include(vehicle => vehicle.HireGroup)
                .Include(vehicle => vehicle.VehicleCategory)
                .Include(vehicle => vehicle.VehicleMake)
                .Include(vehicle => vehicle.VehicleModel)
                .Include(vehicle => vehicle.VehicleStatus)
                .Where(vehicle => vehicle.HireGroupId == request.HireGroupId)
                .OrderBy(vehicleOrderByClause[request.VehicleOrderBy]).Skip(fromRow).Take(toRow).ToList() :
                DbSet
                .Include(vehicle => vehicle.HireGroup)
                .Include(vehicle => vehicle.VehicleCategory)
                .Include(vehicle => vehicle.VehicleMake)
                .Include(vehicle => vehicle.VehicleModel)
                .Include(vehicle => vehicle.VehicleStatus)
                .Where(vehicle => vehicle.HireGroupId == request.HireGroupId)
                .OrderByDescending(vehicleOrderByClause[request.VehicleOrderBy]).Skip(fromRow).Take(toRow).ToList();

            return new GetVehicleResponse { Vehicles = vehicles, TotalCount = DbSet.Count(query) };
        }

        #endregion
    }
}
