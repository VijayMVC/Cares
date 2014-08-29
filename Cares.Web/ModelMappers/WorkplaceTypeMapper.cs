
using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Workplace Type Mapper
    /// </summary>
    public static class WorkplaceTypeMapper
    {
        /// <summary>
        /// Mapper from domain model to web dropdown
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static WorkplaceTypeDropDown CreateFrom(this Cares.Models.DomainModels.WorkPlaceType source)
        {
            return new WorkplaceTypeDropDown
            {
                WorkPlaceTypeId = source.WorkPlaceTypeId,
                WorkPlaceTypeCodeName = source.WorkPlaceTypeCode+" - "+ source.WorkPlaceTypeName
            };
        }
    }
}