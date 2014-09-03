using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Work Location Mapper
    /// </summary>
    public static class WorkLocationMapper
    {
        #region Public
        /// <summary>
        /// Mapper from domain model to web dropdown
        /// </summary>
        public static WorkLocationDropDown CreateFrom(this Cares.Models.DomainModels.WorkLocation source)
        {
            return new WorkLocationDropDown
            {
                CompanyId = source.CompanyId,
                WorkLocationId = source.WorkLocationId,
                WorkLocationCodeName = source.WorkLocationCode + " - " + source.WorkLocationName
            };
        }
        #endregion
    }
}