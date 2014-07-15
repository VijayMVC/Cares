using ApiModel = Cares.Web.Models;
using DomainModel = Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Operation Mapper
    /// </summary>
    public static class OperationMapper
    {
        #region Public
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.Operation CreateFrom(this DomainModel.Operation source)
            {
                return new ApiModel.Operation
                {
                    OperationId = source.OperationId,
                    OperationCode = source.OperationCode,
                    OperationName = source.OperationName
                };
            }
        #endregion
        #region Model To Entity
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModel.Operation CreateFrom(this ApiModel.Operation source)
        {
            return new DomainModel.Operation
            {
                OperationId = source.OperationId,
                OperationCode = source.OperationCode,
                OperationName = source.OperationName
            };
        }
        
        #endregion
        #endregion
    }
}