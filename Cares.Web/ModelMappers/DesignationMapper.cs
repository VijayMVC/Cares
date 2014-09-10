
using Cares.Web.Models;
using DomainModels = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Designation MApper
    /// </summary>
    public static class DesignationMapper
    {
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static DesignationDropDown CreateFrom(this DomainModels.Designation source)
        {
            return new DesignationDropDown
            {
                DesignationId = source.DesignationId,
                DesignationCodeName = source.DesignationCode + " - " + source.DesignationName
            };
        }
    }
}