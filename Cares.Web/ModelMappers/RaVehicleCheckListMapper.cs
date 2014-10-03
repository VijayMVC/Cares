using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// RaVehicle CheckList Mapper
    /// </summary>
    public static class RaVehicleCheckListMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static RaVehicleCheckList CreateFrom(this DomainModels.RaVehicleCheckList source)
        {
             return new RaVehicleCheckList
            {
                RaVehicleCheckListId = source.RaVehicleCheckListId,
                RaHireGroupId = source.RaHireGroupId,
                VehicleCheckListId = source.VehicleCheckListId,
                IsInterior = source.VehicleCheckList != null && source.VehicleCheckList.IsInterior,
                VehicleCheckListCode = source.VehicleCheckList != null ? source.VehicleCheckList.VehicleCheckListCode : string.Empty,
                Status = source.Status,
                VehicleCheckListKey = source.VehicleCheckList != null ? source.VehicleCheckList.VehicleCheckListKey : 0,
                VehicleCheckListName = source.VehicleCheckList != null ? source.VehicleCheckList.VehicleCheckListName : string.Empty
            };
           
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static DomainModels.RaVehicleCheckList CreateFrom(this RaVehicleCheckList source)
        {
            return new DomainModels.RaVehicleCheckList
            {
                RaVehicleCheckListId = source.RaVehicleCheckListId,
                RaHireGroupId = source.RaHireGroupId,
                VehicleCheckListId = source.VehicleCheckListId,
                Status = source.Status
            };

        }

        #endregion

    }
}
