using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;


namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Hire Group Detail Repository
    /// </summary>
    public sealed class HireGroupDetailRepository : BaseRepository<HireGroupDetail>, IHireGroupDetailRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public HireGroupDetailRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<HireGroupDetail> DbSet
        {
            get
            {
                return db.HireGroupDetails;
            }
        }

        #endregion
        
        #region Public

        /// <summary>
        /// Get Hire Groups By Code, Vehicle Make / Category / Model / Model Year
        /// Having no Parent Hire Group
        /// </summary>
        public IEnumerable<HireGroupDetail> GetByCodeAndVehicleInfo(string searchText, long operationWorkPlaceId, DateTime startDtTime, DateTime endDtTime)
        {
            short modelYear;
            bool isModelYear = Int16.TryParse(searchText, out modelYear);

            var query = from hireGroupDetail in DbSet
                        join hireGroup in db.HireGroups on hireGroupDetail.HireGroupId equals hireGroup.HireGroupId
                        join vc in db.VehicleCategories on hireGroupDetail.VehicleCategoryId equals vc.VehicleCategoryId
                        join vm in db.VehicleMakes on hireGroupDetail.VehicleMakeId equals vm.VehicleMakeId
                        join vmod in db.VehicleModels on hireGroupDetail.VehicleModelId equals vmod.VehicleModelId
                        join v in db.Vehicles on new { vc.VehicleCategoryId, vm.VehicleMakeId, vmod.VehicleModelId, hireGroupDetail.ModelYear } equals 
                        new { v.VehicleCategoryId, v.VehicleMakeId, v.VehicleModelId, v.ModelYear }
                        from vs in db.VehicleStatuses.Where(vs => vs.VehicleStatusId == v.VehicleStatusId && 
                            vs.AvailabilityCheck && v.OperationsWorkPlaceId == operationWorkPlaceId)
                        join vr in db.VehicleReservations on v.VehicleId equals vr.VehicleId into vehicleGroup
                        from vg in vehicleGroup.Where(vg => !(vg.EndDtTime >= startDtTime && vg.StartDtTime <= endDtTime)).DefaultIfEmpty()
                        where (((hireGroup.HireGroupCode.Contains(searchText) || hireGroup.HireGroupName.Contains(searchText)) || 
                               (hireGroupDetail.VehicleCategory.VehicleCategoryCode.Contains(searchText) || hireGroupDetail.VehicleCategory.VehicleCategoryName.Contains(searchText)) ||
                               (hireGroupDetail.VehicleMake.VehicleMakeCode.Contains(searchText) || hireGroupDetail.VehicleMake.VehicleMakeName.Contains(searchText)) ||
                               (hireGroupDetail.VehicleModel.VehicleModelCode.Contains(searchText) || hireGroupDetail.VehicleModel.VehicleModelName.Contains(searchText))) &&
                               (!isModelYear || hireGroupDetail.ModelYear == modelYear))
                        orderby hireGroup.HireGroupCode, hireGroup.HireGroupName
                        group hireGroupDetail by new
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
                        } into finalHireGroup
                        select finalHireGroup;

            return query.SelectMany(hg => hg).Distinct().ToList();
        }

        /// <summary>
        /// Get All Vehicle Models for User Domain Key
        /// </summary>
        public override IEnumerable<HireGroupDetail> GetAll()
        {
            return DbSet.Where(vehicleModel => vehicleModel.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get Hire Group detail, based on filter criteria
        /// </summary>
        public IEnumerable<HireGroupDetail> GetHireGroupDetailsForTariffRate()
        {
            return DbSet.Where(h => h.UserDomainKey == UserDomainKey).Include(x => x.HireGroup).ToList();
        }

        /// <summary>
        /// Get Hire Group Detail By Hire Group Id
        /// </summary>
        public IEnumerable<HireGroupDetail> GetHireGroupDetailByHireGroupId(long hireGroupId)
        {
            return DbSet.Where(h => h.HireGroupId == hireGroupId);
        }

        /// <summary>
        /// Association check of HireGroup Detail and Vehicle Make
        /// </summary>
        public bool IsHireGroupDetailAssociatedWithVehicleMake(long vehiclemakeId)
        {
            return DbSet.Count(hiregroupDet => hiregroupDet.VehicleMakeId == vehiclemakeId) > 0;
        }

        /// <summary>
        /// Association check of HireGroup Detail and Vehicle Category
        /// </summary>
        public bool IsHireGroupDetailAssociatedWithVehicleCategory(long vehicleCategoryId)
        {
            return DbSet.Count(hiregroupDet => hiregroupDet.VehicleCategoryId == vehicleCategoryId) > 0;
            
        }

        /// <summary>
        /// Association check of HireGroup Detail and Vehicle Model
        /// </summary>
        public bool IsHireGroupDetailAssociatedWithVehicleModel(long vehicleModelId)
        {
            return DbSet.Count(hiregroupDet => hiregroupDet.VehicleMakeId == vehicleModelId) > 0;
            
        }
        #endregion
    }
}
