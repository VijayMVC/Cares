using Cares.Models.DomainModels;
using ApiModel = Cares.Web.Models;
using DomainModel = Cares.Models.DomainModels;

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
        public static ApiModel.OperationDropDown CreateFrom(this Operation source)
            {
                return new ApiModel.OperationDropDown
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