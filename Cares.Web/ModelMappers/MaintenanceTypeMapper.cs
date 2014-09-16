using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Maintenance Type Mapper
    /// </summary>
    public static class MaintenanceTypeMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static MaintenanceTypeDropDown CreateFromDropDown(this Cares.Models.DomainModels.MaintenanceType source)
        {
            return new MaintenanceTypeDropDown
            {
                MaintenanceTypeId = source.MaintenanceTypeId,
                MaintenanceTypeCodeName = source.MaintenanceTypeCode + " - " + source.MaintenanceTypeName
            };
        }

        #endregion
    }
}