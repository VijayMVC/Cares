using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
using System.Linq;
using ApiModel = Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Operations WorkPlace Mapper
    /// </summary>
    public static class OperationsWorkPlaceMapper
    {
        #region Public
        #region Entity To Model

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.OperationsWorkPlace CreateFrom(this OperationsWorkPlace source)
        {
            return new ApiModel.OperationsWorkPlace
            {
                OperationsWorkPlaceId = source.OperationsWorkPlaceId,
                LocationCode = source.LocationCode,
                CostCenter = source.CostCenter,
                OperationId = source.OperationId,
                WorkPlaceId = source.WorkPlaceId,
                FleetPoolId = source.FleetPoolId,
            };
        }


        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.OperationsWorkPlaceDropDown CreateFromDropDown(this OperationsWorkPlace source)
        {
            return new ApiModel.OperationsWorkPlaceDropDown
            {
                OperationsWorkPlaceId = source.OperationsWorkPlaceId,
                OperationId = source.OperationId,
                OperationsWorkPlaceCodeName = source.LocationCode
            };
        }
        #endregion
        #region Model To Entity

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static OperationsWorkPlace CreateFrom(this ApiModel.OperationsWorkPlace source)
        {
            return new OperationsWorkPlace
            {
                OperationsWorkPlaceId = source.OperationsWorkPlaceId,
                LocationCode = source.LocationCode,
                OperationId = source.OperationId,
                WorkPlaceId = source.WorkPlaceId,
                FleetPoolId = source.FleetPoolId,
                CostCenter = source.CostCenter
            };
        }

        /// <summary>
        ///  Create entity from domain model
        /// </summary>
        public static ApiModel.OperationsWorkPlace CreateFromm(this OperationsWorkPlace source)
        {
            return new ApiModel.OperationsWorkPlace
            {
                WorkPlaceId = source.WorkPlaceId,
                OperationsWorkPlaceId = source.OperationsWorkPlaceId,
                LocationCode = source.LocationCode,
                OperationId = source.OperationId,
                OperationName = source.Operation.OperationName,
                CostCenter = source.CostCenter,
                FleetPoolId = source.FleetPoolId,
                FleetPoolName = source.FleetPoolId != null ? source.FleetPool.FleetPoolName : ""
            };
        }


        /// <summary>
        ///  Create from IEnumerable domainmodel
        /// </summary>
        public static Models.OperationWorkplaceSearchByIdResponse CreateFrommm(this OperationWorkplaceSearchByIdResponse source)
        {
            return new Models.OperationWorkplaceSearchByIdResponse
            {
                OperationWorkPlaces = source.OperationWorkPlaces.Select(opp => opp.CreateFromm())
            };
        }
        #endregion
        #endregion
    }
}