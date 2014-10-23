using System.Linq;
using Cares.Web.Models;
using WorkPlace = Cares.Models.DomainModels.WorkPlace;
using WorkplaceBaseDataResponse = Cares.Models.ResponseModels.WorkplaceBaseDataResponse;
using WorkplaceSearchRequestResponse = Cares.Models.ResponseModels.WorkplaceSearchRequestResponse;

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
                Companies = source.Companies.Select(company => company.CreateFrom()),
                WorkPlaceTypes = source.WorkPlaceTypes.Select(workplce => workplce.CreateFrom()),
                WorkLocations = source.WorkLocations.Select(workLocation => workLocation.CreateFrom()),
                Operations = source.Operations.Select(opperation => opperation.CreateFrom()),
                FleetPools = source.Fleetpools.Select(fleetPool => fleetPool.CreateFromm()),
                ParentWorkPlaces = source.ParentWorkPlaces.Select(workplace => workplace.CreateFromm())
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
                CompanyId = source.WorkLocation.CompanyId,
                CompanyName = source.WorkLocation.Company.CompanyName,
                ParentWorkPlaceId = source.ParentWorkPlaceId,
                ParentWorkPlaceName = source.ParentWorkPlaceId != null ? source.ParentWorkPlace.WorkPlaceName : "",
                WorkPlaceTypeId = source.WorkPlaceTypeId,
                WorkPlaceTypeName = source.WorkPlaceType.WorkPlaceTypeName,
                WorkLocationId = source.WorkLocationId,
                WorkLocationName = source.WorkLocation.WorkLocationName,
                OperationsWorkPlaces = source.OperationsWorkPlaces != null ? source.OperationsWorkPlaces.Select(operationWorkPlace => operationWorkPlace.CreateFrom()).ToList() : null
            };
        }
        /// <summary>
        /// Create from domain model [for dropdowns]
        /// </summary>
        public static WorkPlaceDropdown CreateFromm(this WorkPlace source)
        {
            return new WorkPlaceDropdown
             {
                 WorkPlaceId = source.WorkPlaceId,
                 WorkPlaceCodeName = source.WorkPlaceCode + " - " + source.WorkPlaceName,
                 CompanyId = source.WorkLocation.Company != null ? source.WorkLocation.Company.CompanyId : 0
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
                 OperationsWorkPlaces = source.OperationsWorkPlaces != null ? source.OperationsWorkPlaces.Select(operationWorkPlace => operationWorkPlace.CreateFrom()).ToList() : null,

             };
        }
        #endregion
    }
}