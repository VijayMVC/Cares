using DomainModels=Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Hire Group Detail Mapper
    /// </summary>
    public static class HireGroupDetailMapper
    {
        #region Public
            /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Models.HireGroupDetail CreateFrom(this DomainModels.HireGroupDetail source)
        {
            return new Models.HireGroupDetail
            {
                HireGroupDetailId = source.HireGroupDetailId,
                HireGroup=source.HireGroup != null
                        ? source.HireGroup.HireGroupCode + " - " + source.HireGroup.HireGroupName
                        : string.Empty,
                VehicleMake=source.VehicleMake != null
                        ? source.VehicleMake.VehicleMakeCode + " - " + source.VehicleMake.VehicleMakeName
                        : string.Empty,
                VehicleModel=source.VehicleModel != null
                        ? source.VehicleModel.VehicleModelCode + " - " + source.VehicleModel.VehicleModelName
                        : string.Empty,
                VehicleCategory=source.VehicleCategory != null
                        ? source.VehicleCategory.VehicleCategoryCode + " - " + source.VehicleCategory.VehicleCategoryName
                        : string.Empty,
                ModelYear=source.ModelYear,
                //AllowMileage=
               // ExcessMileageCharge=
                //StandardRate=
               // StartDate=source.
                //EndDate=
            };
        }
        #endregion
    }
}