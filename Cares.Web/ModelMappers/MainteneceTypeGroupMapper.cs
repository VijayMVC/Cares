using Cares.Web.Models;
using System.Linq;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Maintenece Type Group Mapper
    /// </summary>
    public static class MainteneceTypeGroupMapper
    {
        #region Public
        /// <summary>
        /// Crete From web model
        /// </summary>
        public static Cares.Models.DomainModels.MaintenanceTypeGroup CreateFrom(this MaintenanceTypeGroup source)
        {
            return new Cares.Models.DomainModels.MaintenanceTypeGroup
            {
               MaintenanceTypeGroupId = source.MaintenanceTypeGroupId,
               MaintenanceTypeGroupCode = source.MaintenanceTypeGroupCode.Trim(),
               MaintenanceTypeGroupName = source.MaintenanceTypeGroupName,
               MaintenanceTypeGroupDescription = source.MaintenanceTypeGroupDescription
            };
        }

        /// <summary>
        /// Crete From company Response domain model
        /// </summary>
        public static MainteneceTypeGroupSearchRequestResponse CreateFrom(this Cares.Models.ResponseModels.MainteneceTypeGroupSearchRequestResponse source)
        {
            return new MainteneceTypeGroupSearchRequestResponse
            {
                MaintenanceTypeGroups = source.MaintenanceTypeGroups.Select(maintenanceTypeGroup => maintenanceTypeGroup.CreateFromm()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        /// Crete From Domain model
        /// </summary>
        public static MaintenanceTypeGroup CreateFromm(this Cares.Models.DomainModels.MaintenanceTypeGroup source)
        {
            return new MaintenanceTypeGroup
            {
                MaintenanceTypeGroupId = source.MaintenanceTypeGroupId,
                MaintenanceTypeGroupCode = source.MaintenanceTypeGroupCode,
                MaintenanceTypeGroupName = source.MaintenanceTypeGroupName,
                MaintenanceTypeGroupDescription = source.MaintenanceTypeGroupDescription
            };
        }

        /// <summary>
        /// Crete From domain model to dropdown
        /// </summary>
        public static MaintenanceTypeGroupDropDown CreateFrom(this Cares.Models.DomainModels.MaintenanceTypeGroup source)
        {
            return new MaintenanceTypeGroupDropDown
            {
                MaintenanceTypeGroupId = source.MaintenanceTypeGroupId,
                MaintenanceTypeGroupCodeName = source.MaintenanceTypeGroupCode+" - "+source.MaintenanceTypeGroupName
            };
        }
    
        #endregion
    }
}