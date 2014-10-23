using System.Linq;
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


        /// <summary>
        /// Create web base data response form domain base data
        /// </summary>
        public static MaintenanceTypeBaseDataResponse CreateFrom(this Cares.Models.ResponseModels.MaintenanceTypeBaseDataResponse source)
        {
            return new MaintenanceTypeBaseDataResponse
            {
                MaintenanceTypeGroups = source.MaintenanceTypeGroups.Select(maintenanceGroup => maintenanceGroup.CreateFrom())
            };
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static MaintenanceType CreateFrom(this Cares.Models.DomainModels.MaintenanceType source)
        {
            return new MaintenanceType
            {
                MaintenanceTypeId = source.MaintenanceTypeId,
                MaintenanceTypeCode = source.MaintenanceTypeCode,
                MaintenanceTypeName = source.MaintenanceTypeName,
                MaintenanceTypeDescription = source.MaintenanceTypeDescription,
                MaintenanceTypeGroupId = source.MaintenanceTypeGroupId,
                MaintenanceTypeGroupName = source.MaintenanceTypeGroup.MaintenanceTypeGroupName
            };
        }

        /// <summary>
        ///  Create  from web model
        /// </summary>
        public static Cares.Models.DomainModels.MaintenanceType CreateFrom(this MaintenanceType source)
        {
            return new Cares.Models.DomainModels.MaintenanceType
            {
                MaintenanceTypeId = source.MaintenanceTypeId,
                MaintenanceTypeCode = source.MaintenanceTypeCode,
                MaintenanceTypeName = source.MaintenanceTypeName,
                MaintenanceTypeDescription = source.MaintenanceTypeDescription,
                MaintenanceTypeGroupId = source.MaintenanceTypeGroupId,
            };
        }

        /// <summary>
        ///  Create from domain search request response
        /// </summary>
        public static MaintenanceTypeSearchRequestResponse CreateFrom(this Cares.Models.ResponseModels.MaintenanceTypeSearchRequestResponse source)
        {
            return new MaintenanceTypeSearchRequestResponse
            {
                TotalCount = source.TotalCount,
                MaintenanceTypes = source.MaintenanceTypes.Select(maintaintypeType => maintaintypeType.CreateFrom())
            };
        }


        #endregion
    }
}