using Cares.WebApp.Models;

namespace Cares.WebApp.ModelsMapper
{
    /// <summary>
    /// 
    /// </summary>
    public static class AvailableHireGroupMapper
    {
        public static HireGroupDetail CreateFrom(this WebApiHireGroup source)
        {
            return new HireGroupDetail
            {
                HireGroupDetailId = source.HireGroupDetailId,
                VehicleMakeName = source.VehicleMakeName,
                VehilceModelName = source.VehilceModelName,
                VehicleCategoryName = source.VehicleCategoryName,
                ModelYear = source.ModelYear,
                RentalCharge = source.RentalCharge,
                ImageSource = source.ImageSource,
            };
        }
    }
}