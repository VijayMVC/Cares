using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;
using DomainModel = Cares.Models.DomainModels;

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
                OperationId = source.OperationId,
                WorkPlaceId = source.WorkPlaceId
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
                WorkPlaceId = source.WorkPlaceId
            };
        }

        #endregion

        #endregion
    }
}