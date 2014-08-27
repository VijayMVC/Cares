using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Vehicle Check List Mapper
    /// </summary>
    public static class VehicleCheckListMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static VehicleCheckListDropDown CreateFromDropDown(this Cares.Models.DomainModels.VehicleCheckList source)
        {
            return new VehicleCheckListDropDown
            {
                VehicleCheckListId = source.VehicleCheckListId,
                VehicleCheckListCodeName = source.VehicleCheckListCode + " - " + source.VehicleCheckListName
            };
        }

        #endregion
    }
}