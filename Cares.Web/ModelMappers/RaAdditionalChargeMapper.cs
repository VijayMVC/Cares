using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// RaAdditionalCharge Mapper
    /// </summary>
    public static class RaAdditionalChargeMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static RaAdditionalCharge CreateFrom(this DomainModels.RaAdditionalCharge source)
        {
            return new RaAdditionalCharge
            {
                RaAdditionalChargeId = source.RaAdditionalChargeId,
                RaMainId = source.RaMainId,
                Quantity = source.Quantity,
                HireGroupDetailId = source.HireGroupDetailId,
                AdditionalChargeRate = source.AdditionalChargeRate,
                AdditionalChargeTypeCodeName = source.AdditionalChargeType != null ? 
                source.AdditionalChargeType.AdditionalChargeTypeCode + "-" + source.AdditionalChargeType.AdditionalChargeTypeName : string.Empty,
                AdditionalChargeTypeId = source.AdditionalChargeTypeId,
                HireGroupCodeName = source.HireGroupDetail != null && source.HireGroupDetail.HireGroup != null ? 
                source.HireGroupDetail.HireGroup.HireGroupCode + '-' + source.HireGroupDetail.HireGroup.HireGroupName : string.Empty,
                PlateNumber = source.PlateNumber
            };
           
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static DomainModels.RaAdditionalCharge CreateFrom(this RaAdditionalCharge source)
        {
            return new DomainModels.RaAdditionalCharge
            {
                RaAdditionalChargeId = source.RaAdditionalChargeId,
                RaMainId = source.RaMainId,
                Quantity = source.Quantity,
                HireGroupDetailId = source.HireGroupDetailId,
                AdditionalChargeRate = source.AdditionalChargeRate,
                AdditionalChargeTypeId = source.AdditionalChargeTypeId,
                PlateNumber = source.PlateNumber
            };

        }

        #endregion

    }
}
