using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;
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
                        { VehicleOrderByColumn.VehicleName, c => c.VehicleName },
                        
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

        public IList<RptFleetHireGroupDetail> GetFleetReport()
        {
            var fleetHireGroupDetailQuery = from vehicle in DbSet                
                join hgd in db.HireGroupDetails on
                    new {ModelID = vehicle.VehicleModelId, MakeID = vehicle.VehicleMakeId, CategoryId = vehicle.VehicleCategoryId, Year= vehicle.ModelYear }
                    equals new { ModelID = hgd.VehicleMakeId, MakeID = hgd.VehicleMakeId, CategoryId = hgd.VehicleCategoryId, Year = hgd.ModelYear }
                select new RptFleetHireGroupDetail
                {
                    HireGroupName = hgd.HireGroup.HireGroupName,
                    PlateNumber = vehicle.PlateNumber,
                 //   ParentHireGroupName = hgd.HireGroup.ParentHireGroup.HireGroupName,
                    VehicleMakeName = vehicle.VehicleMake.VehicleMakeName,
                    FleetPoolName=vehicle.FleetPool.FleetPoolName,
                    VehicleModelName = vehicle.VehicleModel.VehicleModelName,
                    VehicleCategoryName=vehicle.VehicleCategory.VehicleCategoryName,
                    ModelYear=vehicle.ModelYear,
                    Color=vehicle.Color,
                    CurrentOdometer=vehicle.CurrentOdometer,
                    VehicleStatusName= vehicle.VehicleStatus.VehicleStatusName,
                    VehicleAge= DateTime.Now.Year - vehicle.ModelYear,
                    Location= vehicle.OperationsWorkPlace.LocationCode
                };
            return fleetHireGroupDetailQuery.OrderBy(fhgd => fhgd.FleetPoolName).ToList();
        }



        /// <summary>
        /// Get By Hire Group
        /// </summary>
        public GetVehicleResponse GetByHireGroup(VehicleSearchRequest request)
        {
            Expression<Func<Vehicle, bool>> query = vehicle =>
                (vehicle.HireGroup.HireGroupDetails.Any(hgd => hgd.HireGroupDetailId == request.HireGroupDetailId)) &&
                (vehicle.OperationsWorkPlaceId == request.OperationsWorkPlaceId) &&
                (vehicle.VehicleReservations.Count == 0 ||
                !vehicle.VehicleReservations.Any(vehicleReservation => vehicleReservation.EndDtTime >= request.StarDtTime &&
                    vehicleReservation.StartDtTime <= request.EndDtTime));

            IEnumerable<Vehicle> vehicles = request.IsAsc ? DbSet
                .Include(vehicle => vehicle.HireGroup)
                .Include(vehicle => vehicle.HireGroup.HireGroupDetails)
                .Include(vehicle => vehicle.VehicleCategory)
                .Include(vehicle => vehicle.VehicleMake)
                .Include(vehicle => vehicle.VehicleModel)
                .Include(vehicle => vehicle.VehicleStatus)
                .Where(query)
                .OrderBy(vehicleOrderByClause[request.VehicleOrderBy]).ToList() :
                DbSet
                .Include(vehicle => vehicle.HireGroup)
                .Include(vehicle => vehicle.VehicleCategory)
                .Include(vehicle => vehicle.VehicleMake)
                .Include(vehicle => vehicle.VehicleModel)
                .Include(vehicle => vehicle.VehicleStatus)
                .Where(query)
                .OrderByDescending(vehicleOrderByClause[request.VehicleOrderBy]).ToList();

            return new GetVehicleResponse { Vehicles = vehicles, TotalCount = DbSet.Count(query) };
        }

        /// <summary>
        /// Get Vehicle List Based On Search Criteria
        /// </summary>
        public GetVehicleResponse GetVehicles(VehicleSearchRequest request)
        {
            int fromRow = (request.PageNo - 1) * request.PageSize;
            int toRow = request.PageSize;
            Expression<Func<Vehicle, bool>> query =
                s => (string.IsNullOrEmpty(request.SearchString) || s.VehicleName.Contains(request.SearchString) || s.PlateNumber.Contains(request.SearchString))
                    && (string.IsNullOrEmpty(request.HireGroupString) || s.VehicleMake.VehicleMakeCode.Contains(request.HireGroupString) || s.VehicleMake.VehicleMakeName.Contains(request.HireGroupString)
                    || s.VehicleModel.VehicleModelCode.Contains(request.HireGroupString) || s.VehicleModel.VehicleModelName.Contains(request.HireGroupString)
                    || s.VehicleCategory.VehicleCategoryCode.Contains(request.HireGroupString) || s.VehicleCategory.VehicleCategoryName.Contains(request.HireGroupString))
                    && (request.OperationId == null || s.OperationsWorkPlace.Operation.OperationId == request.OperationId) &&
                     (request.FleetPoolId == null ||
                      s.FleetPoolId == request.FleetPoolId);

            IEnumerable<Vehicle> vehicles = request.IsAsc ? DbSet.Where(query)
                                            .OrderBy(vehicleOrderByClause[request.VehicleOrderBy]).Skip(fromRow).Take(toRow).ToList()
                                            : DbSet.Where(query)
                                                .OrderByDescending(vehicleOrderByClause[request.VehicleOrderBy]).Skip(fromRow).Take(toRow).ToList();

            return new GetVehicleResponse { Vehicles = vehicles, TotalCount = DbSet.Count(query) };
        }

        /// <summary>
        /// Association check b/n vehicle and vehicle make
        /// </summary>
        public bool IsVehicleMakeAssociatedWithVehicle(long vehicleMakeId)
        {
            return DbSet.Count(vehicle => vehicle.VehicleMakeId == vehicleMakeId) > 0;
        }

        /// <summary>
        /// Association check b/n vehicle and vehicle Category
        /// </summary>
        public bool IsVehicleCategoryAssociatedWithVehicle(long vehicleCategoryId)
        {
            return DbSet.Count(vehicle => vehicle.VehicleCategoryId == vehicleCategoryId) > 0;
        }

        /// <summary>
        /// Association check b/n vehicle and vehicle Status
        /// </summary>
        public bool IsVehicleStatusAssociatedWithVehicle(long vehicleStatusId)
        {
            return DbSet.Count(vehicle => vehicle.VehicleStatusId == vehicleStatusId) > 0;
            
        }

         /// <summary>
        /// Association check b/n vehicle and vehicle Model
        /// </summary>
        public bool IsVehicleModelAssociatedWithVehicle(long vehicleModelId)
        {
            return DbSet.Count(vehicle => vehicle.VehicleModelId == vehicleModelId) > 0;

        }

        /// <summary>
        /// Load Dependencies
        /// </summary>
        public void LoadDependencies(Vehicle vehicle)
        {
            //LoadProperty(vehicle, () => vehicle.OperationsWorkPlace);
            LoadProperty(vehicle, () => vehicle.VehicleMake);
            LoadProperty(vehicle, () => vehicle.VehicleStatus);
            //LoadProperty(vehicle, () => vehicle.FleetPool);
        }

        /// <summary>
        /// Check Vehicle Plate Number Already Exist
        /// </summary>
        public bool DuplicateVehiclePlateNumber(string plateNumber, long vehiclId)
        {
            return DbSet.Any(x => x.PlateNumber == plateNumber && x.VehicleId != vehiclId);
        }

        /// <summary>
        /// Get Vehicle Info For NRT
        /// </summary>
        public IEnumerable<Vehicle> GetVehicleInfoForNrt(long operationWorkPlaceId, DateTime startDtTime,
            DateTime endDtTime)
        {
            return
                DbSet.Where(
                    vehicle =>
                        vehicle.OperationsWorkPlaceId == operationWorkPlaceId &&
                        (vehicle.VehicleReservations.Count == 0 ||
                         !vehicle.VehicleReservations.Any(
                             vehicleReservation =>
                                 vehicleReservation.EndDtTime >= startDtTime &&
                                 vehicleReservation.StartDtTime <= endDtTime)) && vehicle.UserDomainKey == UserDomainKey).ToList();
        }
        #endregion
    }
}
