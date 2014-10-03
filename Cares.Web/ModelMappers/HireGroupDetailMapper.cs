using System.Linq;
using DomainModel=Cares.Models.DomainModels;
using Cares.Web.Models;

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
        public static HireGroupDetailContent CreateFrom(this DomainModel.HireGroupDetail source)
        {
           
            return new HireGroupDetailContent
            {
                HireGroupDetailId = source.HireGroupDetailId,
                HireGroup = source.HireGroup != null
                        ? source.HireGroup.HireGroupCode + " - " + source.HireGroup.HireGroupName
                        : string.Empty,
                VehicleMake = source.VehicleMake != null
                        ? source.VehicleMake.VehicleMakeCode + " - " + source.VehicleMake.VehicleMakeName
                        : string.Empty,
                VehicleModel = source.VehicleModel != null
                        ? source.VehicleModel.VehicleModelCode + " - " + source.VehicleModel.VehicleModelName
                        : string.Empty,
                VehicleCategory = source.VehicleCategory != null
                        ? source.VehicleCategory.VehicleCategoryCode + " - " + source.VehicleCategory.VehicleCategoryName
                        : string.Empty,
                ModelYear = source.ModelYear,
                HireGroupId = source.HireGroupId,
               
            };
        }

        public static HireGroupDetailForAddtionalCharge CreateFromForAddtionalCharge(this DomainModel.HireGroupDetail source)
        {
            string hireGroup = source.HireGroup != null
                ? source.HireGroup.HireGroupCode + " - " + source.HireGroup.HireGroupName
                : string.Empty;
            string vehicleMake = source.VehicleMake != null
                ? source.VehicleMake.VehicleMakeCode + " - " + source.VehicleMake.VehicleMakeName
                : string.Empty;
            string vehicleModel = source.VehicleModel != null
                ? source.VehicleModel.VehicleModelCode + " - " + source.VehicleModel.VehicleModelName
                : string.Empty;
            string vehicleCategory = source.VehicleCategory != null
                ? source.VehicleCategory.VehicleCategoryCode + " - " + source.VehicleCategory.VehicleCategoryName
                : string.Empty;
            string modelYear = source.ModelYear.ToString();
               
            return new HireGroupDetailForAddtionalCharge
            {
                HireGroupDetailId = source.HireGroupDetailId,
                HireGroupDetailCodeName = hireGroup + " | " + vehicleMake + " | " + vehicleModel + " | " + vehicleCategory + " | " + modelYear
            };
        }
        #endregion
    }
}