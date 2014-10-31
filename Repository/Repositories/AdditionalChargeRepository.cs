using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
using Cares.Repository.BaseRepository;
using Microsoft.Practices.Unity;

namespace Cares.Repository.Repositories
{
    /// <summary>
    /// Additional Charge Repository
    /// </summary>
    public class AdditionalChargeRepository : BaseRepository<AdditionalCharge>, IAdditionalChargeRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public AdditionalChargeRepository(IUnityContainer container)
            : base(container)
        {

        }
        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<AdditionalCharge> DbSet
        {
            get
            {
                return db.AdditionalCharges;
            }
        }
        #endregion

        #region Public

        /// <summary>
        /// Get All Additional Charge for User Domain Key
        /// </summary>
        public override IEnumerable<AdditionalCharge> GetAll()
        {
            return DbSet.Where(addChrg => addChrg.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get Additional Charges By Addition Charge Type Id
        /// </summary>
        /// <param name="additionChargeTypeId"></param>
        /// <returns></returns>
        public IEnumerable<AdditionalCharge> GetAdditionalChargesByAdditionChargeTypeId(long additionChargeTypeId)
        {
            return
                DbSet.Where(
                    addChrg =>
                        addChrg.ChildAdditionalChargeId == null &&
                        addChrg.AdditionalChargeTypeId == additionChargeTypeId && addChrg.UserDomainKey == UserDomainKey).ToList();
        }

        /// <summary>
        /// Get All For Ra
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AdditionalCharge> GetAllForRa()
        {
            return DbSet.Where(addChrg => addChrg.UserDomainKey == UserDomainKey && addChrg.ChildAdditionalChargeId == null).ToList();
        }


        /// <summary>
        /// Get Additional Charge For NRT
        /// </summary>
        /// <param name="startDt"></param>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public IEnumerable<AdditionalChargeForNrt> AdditionalChargeForNrt(DateTime startDt, Vehicle vehicle)
        {
            var query = from additionalCharge in DbSet
                        join hgDetail in db.HireGroupDetails on additionalCharge.HireGroupDetailId equals
                            hgDetail.HireGroupDetailId
                        where
                            (additionalCharge.StartDt <= startDt && hgDetail.VehicleCategory.VehicleCategoryId == vehicle.VehicleCategoryId
                            && hgDetail.VehicleMake.VehicleMakeId == vehicle.VehicleMakeId && hgDetail.VehicleModel.VehicleModelId == vehicle.VehicleModelId
                            && hgDetail.ModelYear == vehicle.ModelYear && additionalCharge.UserDomainKey == UserDomainKey && hgDetail.UserDomainKey == UserDomainKey)
                        select new AdditionalChargeForNrt
                {
                    AdditionalChargeTypeCode = additionalCharge.AdditionalChargeType.AdditionalChargeTypeCode,
                    AdditionalChargeTypeName = additionalCharge.AdditionalChargeType.AdditionalChargeTypeName,
                    AdditionalChargeRate = additionalCharge.AdditionalChargeRate,
                    AdditionalChargeTypeId = additionalCharge.AdditionalChargeType.AdditionalChargeTypeId,
                    HireGroupDetail = hgDetail.HireGroup.HireGroupCode + "-" + hgDetail.HireGroup.HireGroupName + " | " +
                    hgDetail.VehicleMake.VehicleMakeCode + "-" + hgDetail.VehicleMake.VehicleMakeName + " | " +
                     hgDetail.VehicleModel.VehicleModelCode + "-" + hgDetail.VehicleModel.VehicleModelName + " | " +
                     hgDetail.VehicleCategory.VehicleCategoryCode + "-" + hgDetail.VehicleCategory.VehicleCategoryName + " | " + hgDetail.ModelYear
                };
            return query.ToList();
        }
        #endregion
    }
}
