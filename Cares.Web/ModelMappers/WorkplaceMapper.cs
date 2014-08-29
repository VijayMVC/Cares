using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Work place Mapper
    /// </summary>
    public static class WorkplaceMapper
    {
        #region Public
        /// <summary>
        /// Create From Response Model to web basedata
        /// </summary>
        public static Models.WorkplaceBaseDataResponse CreateFrom(this WorkplaceBaseDataResponse source)
        {
            return new Models.WorkplaceBaseDataResponse
            {
                Companies =      source.Companies.Select(company => company.CreateFrom()),
                WorkPlaceTypes = source.WorkPlaceTypes.Select(workplce => workplce.CreateFrom()),
                WorkLocations = source.WorkLocations.Select(workLocation => workLocation.CreateFrom())
            };
        }

        /// <summary>
        /// Create From Response model to web search response
        /// </summary>
        public static Models.WorkplaceSearchRequestResponse CreateFrom(this WorkplaceSearchRequestResponse source)
        {
            return new Models.WorkplaceSearchRequestResponse
            {
                WorkPlaces = source.WorkPlaces.Select(operation => operation.CreateFrom()),
                TotalCount = source.TotalCount
            };
        }

        /// <summary>
        /// Create From Domain model
        /// </summary>
        public static Models.WorkPlace CreateFrom(this WorkPlace source)
        {
            return new Models.WorkPlace
            {
                WorkPlaceId = source.WorkPlaceId,
                WorkPlaceCode = source.WorkPlaceCode,
                WorkPlaceName = source.WorkPlaceName,
                WorkPlaceDescription = source.WorkPlaceDescription,
                CompanyId = source.WorkLocation.CompanyId ,
                CompanyName =  source.WorkLocation.Company.CompanyName,
                ParentWorkPlaceId = source.ParentWorkPlaceId,
                ParentWorkPlaceName = source.ParentWorkPlaceId!=null ? source.ParentWorkPlace.WorkPlaceName : "EmptY",
                WorkPlaceTypeId = source.WorkPlaceTypeId,
                WorkPlaceTypeName = source.WorkPlaceType.WorkPlaceTypeName,
                WorkLocationId = source.WorkLocationId,
                WorkLocationName = source.WorkLocation.WorkLocationName
            };
        }

        /// <summary>
        /// Create From Web model
        /// </summary>
        public static WorkPlace CreateFrom(this Models.WorkPlace source)
        {
            return new WorkPlace
            {
                WorkPlaceId = source.WorkPlaceId,
                WorkPlaceCode = source.WorkPlaceCode,
                WorkPlaceName = source.WorkPlaceName,
                WorkPlaceDescription = source.WorkPlaceDescription,
                ParentWorkPlaceId = source.ParentWorkPlaceId,
                WorkPlaceTypeId = source.WorkPlaceTypeId,
                WorkLocationId = source.WorkLocationId,
                CompanyId= source.CompanyId
            };
        } 
        #endregion
    }
}