using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
            var fleetHireGroupDetailQuery = from vehicle in db.Vehicles                
                                            join hgd in db.HireGroupDetails on
                    new { vehicle.VehicleModelId, vehicle.VehicleMakeId,vehicle.VehicleCategoryId, vehicle.ModelYear }
                    equals new { hgd.VehicleModelId, hgd.VehicleMakeId,  hgd.VehicleCategoryId, hgd.ModelYear }
                                            select new RptFleetHireGroupDetail
                                            {
                                                HireGroupName = hgd.HireGroup.HireGroupName,
                                                PlateNumber = vehicle.PlateNumber,
                                                ParentHireGroupName = hgd.HireGroup.ParentHireGroup != null ? "Parent Hire Group " : string.Empty,
                                                VehicleMakeName = vehicle.VehicleMake.VehicleMakeName,
                                                FleetPoolName = vehicle.FleetPool.FleetPoolName,
                                                VehicleModelName = vehicle.VehicleModel.VehicleModelName,
                                                VehicleCategoryName = vehicle.VehicleCategory.VehicleCategoryName,
                                                ModelYear = vehicle.ModelYear,
                                                Color = vehicle.Color,
                                                CurrentOdometer = vehicle.CurrentOdometer,
                                                VehicleStatusName = vehicle.VehicleStatus.VehicleStatusName,
                                                VehicleAge = (DateTime.Now.Year - vehicle.ModelYear) * 12,
                                                Location = vehicle.OperationsWorkPlace.LocationCode
                                            };
            
            return fleetHireGroupDetailQuery.OrderBy(fhgd => fhgd.FleetPoolName).ToList();
        }



        /// <summary>
        /// Get By Hire Group
        /// </summary>
        public GetVehicleResponse GetByHireGroup(VehicleSearchRequest request)
        {

            var query = from hireGroupDetail in db.HireGroupDetails
                        from hireGroup in db.HireGroups.Where(hg => hg.HireGroupId == hireGroupDetail.HireGroupId &&
                            (hireGroupDetail.HireGroupDetailId == request.HireGroupDetailId || request.HireGroupDetailId == 0))
                        join vc in db.VehicleCategories on hireGroupDetail.VehicleCategoryId equals vc.VehicleCategoryId
                        join vm in db.VehicleMakes on hireGroupDetail.VehicleMakeId equals vm.VehicleMakeId
                        join vmod in db.VehicleModels on hireGroupDetail.VehicleModelId equals vmod.VehicleModelId
                        join v in db.Vehicles on new { vc.VehicleCategoryId, vm.VehicleMakeId, vmod.VehicleModelId, hireGroupDetail.ModelYear } equals
                        new { v.VehicleCategoryId, v.VehicleMakeId, v.VehicleModelId, v.ModelYear }
                        from vs in db.VehicleStatuses.Where(vs => vs.VehicleStatusId == v.VehicleStatusId && vs.AvailabilityCheck)
                        join fleetPool in db.FleetPools on v.FleetPoolId equals fleetPool.FleetPoolId
                        from owp in db.OperationsWorkPlaces.Where(owp => owp.FleetPoolId == fleetPool.FleetPoolId && owp.OperationsWorkPlaceId == request.OperationsWorkPlaceId)
                        where owp.OperationsWorkPlaceId == request.OperationsWorkPlaceId
                        join vr in db.VehicleReservations on v.VehicleId equals vr.VehicleId into vehicleGroup
                        from vg in vehicleGroup.Where(vg => !(vg.EndDtTime >= request.StartDtTime && vg.StartDtTime <= request.EndDtTime)).DefaultIfEmpty()
                        orderby hireGroup.HireGroupCode, hireGroup.HireGroupName
                        group v by new
                        {
                            hireGroup.HireGroupId,
                            hireGroup.HireGroupCode,
                            hireGroup.HireGroupName,
                            hireGroupDetail.HireGroupDetailId,
                            hireGroupDetail.VehicleCategoryId,
                            hireGroupDetail.VehicleMakeId,
                            hireGroupDetail.VehicleModelId,
                            vm.VehicleMakeCode,
                            vm.VehicleMakeName,
                            vc.VehicleCategoryCode,
                            vc.VehicleCategoryName,
                            vmod.VehicleModelCode,
                            vmod.VehicleModelName,
                            v.ModelYear
                        } into vehicle
                        select vehicle;

            return new GetVehicleResponse { Vehicles = query.SelectMany(hgd => hgd).Distinct().ToList() };
        }

        /// <summary>
        /// Get Upgraded Vehicles By HireGroup
        /// </summary>
        public GetVehicleResponse GetUpgradedVehiclesByHireGroup(VehicleSearchRequest request)
        {
            var subQuery = from hireGroupDetail in db.HireGroupDetails
                           from hireGroupUpgrade in db.HireGroupUpGrades.Where(hgu => hgu.HireGroupId == hireGroupDetail.HireGroupId &&
                               (hireGroupDetail.HireGroupDetailId == request.HireGroupDetailId || request.HireGroupDetailId == 0)).DefaultIfEmpty()
                           from hireGroup in db.HireGroups.Where(hg => hg.HireGroupId == hireGroupDetail.HireGroupId &&
                               (hireGroupDetail.HireGroupDetailId == request.HireGroupDetailId || request.HireGroupDetailId == 0) || 
                               (hireGroupUpgrade.AllowedHireGroupId == hg.HireGroupId))
                           select hireGroupDetail;

            var query = from hireGroupDetail in db.HireGroupDetails
                        join hireGroup in subQuery on hireGroupDetail.HireGroupId equals hireGroup.HireGroupId
                        join vc in db.VehicleCategories on hireGroupDetail.VehicleCategoryId equals vc.VehicleCategoryId
                        join vm in db.VehicleMakes on hireGroupDetail.VehicleMakeId equals vm.VehicleMakeId
                        join vmod in db.VehicleModels on hireGroupDetail.VehicleModelId equals vmod.VehicleModelId
                        join v in db.Vehicles on new { vc.VehicleCategoryId, vm.VehicleMakeId, vmod.VehicleModelId, hireGroupDetail.ModelYear } equals
                        new { v.VehicleCategoryId, v.VehicleMakeId, v.VehicleModelId, v.ModelYear }
                        from vs in db.VehicleStatuses.Where(vs => vs.VehicleStatusId == v.VehicleStatusId && vs.AvailabilityCheck)
                        join fleetPool in db.FleetPools on v.FleetPoolId equals fleetPool.FleetPoolId
                        from owp in db.OperationsWorkPlaces.Where(owp => owp.FleetPoolId == fleetPool.FleetPoolId && owp.OperationsWorkPlaceId == request.OperationsWorkPlaceId)
                        join vr in db.VehicleReservations on v.VehicleId equals vr.VehicleId into vehicleGroup
                        from vg in vehicleGroup.Where(vg => !(vg.EndDtTime >= request.StartDtTime && vg.StartDtTime <= request.EndDtTime)).DefaultIfEmpty()
                        orderby hireGroup.HireGroup.HireGroupCode, hireGroup.HireGroup.HireGroupName
                        group v by new
                        {
                            hireGroup.HireGroupId,
                            hireGroup.HireGroup.HireGroupCode,
                            hireGroup.HireGroup.HireGroupName,
                            hireGroupDetail.HireGroupDetailId,
                            hireGroupDetail.VehicleCategoryId,
                            hireGroupDetail.VehicleMakeId,
                            hireGroupDetail.VehicleModelId,
                            vm.VehicleMakeCode,
                            vm.VehicleMakeName,
                            vc.VehicleCategoryCode,
                            vc.VehicleCategoryName,
                            vmod.VehicleModelCode,
                            vmod.VehicleModelName,
                            v.ModelYear
                        } into vehicle
                        select vehicle;

            return new GetVehicleResponse { Vehicles = query.SelectMany(hgd => hgd).Distinct().ToList() };
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
            //LoadProperty(vehicle, () => vehicle.VehicleMake);
            //LoadProperty(vehicle, () => vehicle.VehicleStatus);
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
