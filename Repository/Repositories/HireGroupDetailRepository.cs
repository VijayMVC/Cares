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
            return DbSet
                .Include("HireGroup")
                .Include("VehicleCategory")
                .Include("VehicleMake")
                .Include("VehicleModel")
                .Where(hg => (string.IsNullOrEmpty(searchText) ||
                                      ((hg.HireGroup.HireGroupCode.Contains(searchText) || hg.HireGroup.HireGroupName.Contains(searchText)) ||
                                       (hg.VehicleMake.VehicleMakeCode.Contains(searchText) || hg.VehicleMake.VehicleMakeName.Contains(searchText)) ||
                                       (hg.VehicleCategory.VehicleCategoryCode.Contains(searchText) || hg.VehicleCategory.VehicleCategoryName.Contains(searchText)) ||
                                       (hg.VehicleModel.VehicleModelCode.Contains(searchText) || hg.VehicleModel.VehicleModelName.Contains(searchText)) ||
                                       (!isModelYear || hg.ModelYear == modelYear)))
                                       && (!hg.HireGroup.ParentHireGroupId.HasValue)
                                       && (hg.HireGroup.Vehicles.Any(vehicle => vehicle.OperationsWorkPlaceId == operationWorkPlaceId && 
                                           (vehicle.VehicleReservations.Count == 0 || 
                                           !vehicle.VehicleReservations.Any(vehicleReservation => vehicleReservation.EndDtTime >= startDtTime && vehicleReservation.StartDtTime <= endDtTime)))))
                                      .OrderBy(hg => hg.HireGroup.HireGroupCode).ThenBy(hg => hg.HireGroup.HireGroupName).Take(10).ToList();
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
        #endregion
    }
}
