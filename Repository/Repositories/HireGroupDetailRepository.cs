using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Web.Security.AntiXss;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.DomainModels;
using Cares.Models.ReportModels;
using Cares.Models.ResponseModels;
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

        /// <summary>
        /// GetHire Group Detail By Vehicle Make Id, Model Id, Category Id, Model Year 
        /// </summary>
        /// <param name="vMakeId"></param>
        /// <param name="vModelId"></param>
        /// <param name="vCategoryId"></param>
        /// <param name="modelYear"></param>
        /// <returns></returns>
        public HireGroupDetail GetHireGroupDetailByVehicleMakeIdModelIdCategoryIdModelYear(long vMakeId, long vModelId, long vCategoryId, short modelYear)
        {
            return DbSet.FirstOrDefault(hGd => hGd.VehicleMakeId == vMakeId && hGd.VehicleModelId == vModelId && hGd.VehicleCategoryId == vCategoryId && hGd.ModelYear == modelYear);
        }

        /// <summary>
        /// user domainKey
        /// </summary>
        public IEnumerable<WebApiAvailableHireGroupsApiResponse> GetAvailableVehicleInfoForWebApi(
            long operationWorkPlaceId, DateTime startDtTime, DateTime endDtTime, long userDomainKey)
        {
            operationWorkPlaceId = 21;
            startDtTime=new DateTime(2014,11,19);
            endDtTime= new DateTime(2014,11,20);
            userDomainKey = 1;

            #region Join
            var query = from vehicle in db.Vehicles
                join hgd in db.HireGroupDetails
                    on new{ vehicle.VehicleModelId,  vehicle.VehicleMakeId, vehicle.VehicleCategoryId,vehicle.ModelYear} 
                equals new{hgd.VehicleModelId,hgd.VehicleMakeId, hgd.VehicleCategoryId, hgd.ModelYear }
                into hireGroups from hgd in hireGroups.DefaultIfEmpty()
                   join vr in db.VehicleReservations on vehicle.VehicleId equals vr.VehicleId into vehicleGroup
                   from vg in vehicleGroup.
                Where(vg => !(vg.EndDtTime >= startDtTime && vg.StartDtTime <= endDtTime)).DefaultIfEmpty()
            #endregion
            #region Where
                        where vehicle.VehicleStatus.VehicleStatusKey==(int)VehicleStatusEnum.Available &&
                vehicle.UserDomainKey==userDomainKey  && vehicle.OperationsWorkPlaceId== operationWorkPlaceId
            #endregion
            #region Select
                        select new WebApiAvailableHireGroupsApiResponse
                {
                    Image= vehicle.VehicleImages.FirstOrDefault().Image,
                    ModelYear = vehicle.ModelYear,
                    VehicleCategory = vehicle.VehicleCategory.VehicleCategoryCode,
                    VehicleMake = vehicle.VehicleMake.VehicleMakeCode,
                    VehicleModel = vehicle.VehicleModel.VehicleModelCode,
                    NumberPlate = vehicle.PlateNumber,
                    StandardRate =  (hgd.StandardRates.Where(rate=> rate.StandardRtStartDt<=startDtTime).OrderBy(x=>x.StandardRtStartDt).FirstOrDefault().StandardRt)!=null ?
                    (hgd.StandardRates.Where(rate=> rate.StandardRtStartDt<=startDtTime).OrderBy(x=>x.StandardRtStartDt).FirstOrDefault().StandardRt):0,
                    HireGroupName = hgd.HireGroup!=null ? hgd.HireGroup.HireGroupCode: string.Empty,
                    AllowedMileage = (hgd.StandardRates.
                    Where(rate => rate.StandardRtStartDt <= startDtTime).OrderBy(x => x.StandardRtStartDt).FirstOrDefault().AllowedMileage) !=null ?
                    (hgd.StandardRates.
                    Where(rate => rate.StandardRtStartDt <= startDtTime).OrderBy(x => x.StandardRtStartDt).FirstOrDefault().AllowedMileage):0
                };
                        #endregion
            return query.OrderBy(vehicle => vehicle.ModelYear).ToList();
        }
        #endregion
    }
}
