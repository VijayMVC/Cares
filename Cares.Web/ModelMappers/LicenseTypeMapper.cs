using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;


namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// License Type Mapper
    /// </summary>
    public static class LicenseTypeMapper
    {
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static LicenseTypeDropDown CreateFrom(this DomainModels.LicenseType source)
        {
            return new LicenseTypeDropDown
            {
                LicenseTypeId = source.LicenseTypeId,
                LicenseTypeCodeName = source.LicenseTypeCode + " - " + source.LicenseTypeName
            };
        }
    }
}