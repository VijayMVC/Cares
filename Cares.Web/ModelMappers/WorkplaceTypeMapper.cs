
using Cares.Web.Models;
using System.Linq;
using WorkPlaceTypeSearchRequestResponse = Cares.Models.ResponseModels.WorkPlaceTypeSearchRequestResponse;

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
        public static WorkplaceTypeDropDown CreateDropdownFrom(this Cares.Models.DomainModels.WorkPlaceType source)
        {
            return new WorkplaceTypeDropDown
            {
                WorkPlaceTypeId = source.WorkPlaceTypeId,
                WorkPlaceTypeCodeName = source.WorkPlaceTypeCode+" - "+ source.WorkPlaceTypeName
            };
        }


        /// <summary>
        /// Crete From WorkPlace Type Response domain model to web model
        /// </summary>
        public static Models.WorkPlaceTypeSearchRequestResponse CreateFrom(this WorkPlaceTypeSearchRequestResponse source)
        {
            return new Models.WorkPlaceTypeSearchRequestResponse
            {
                WorkPlaceTypes = source.WorkPlaceTypes.Select(workPlacetype => workPlacetype.CreateFrom()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        /// Crete From  domain model  to  web model
        /// </summary>
        public static WorkPlaceType CreateFrom(this Cares.Models.DomainModels.WorkPlaceType source)
        {
            return new WorkPlaceType
            {
                WorkPlaceTypeId = source.WorkPlaceTypeId,
                WorkPlaceTypeCode = source.WorkPlaceTypeCode,
                WorkPlaceTypeName = source.WorkPlaceTypeName,
                WorkPlaceTypeDescription = source.WorkPlaceTypeDescription,
                WorkPlaceNature = source.WorkPlaceNature
            };
        }


        /// <summary>
        /// Mapper from  web model to domain
        /// </summary>
        public static Cares.Models.DomainModels.WorkPlaceType CreateFrom(this WorkPlaceType source)
        {
            return new Cares.Models.DomainModels.WorkPlaceType
            {
                WorkPlaceTypeId = source.WorkPlaceTypeId,
                WorkPlaceTypeCode = source.WorkPlaceTypeCode.Trim(),
                WorkPlaceTypeName = source.WorkPlaceTypeName,
                WorkPlaceTypeDescription = source.WorkPlaceTypeDescription,
                WorkPlaceNature = source.WorkPlaceNature
            };
        }
    }
}