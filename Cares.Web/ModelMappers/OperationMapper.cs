
using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    public static class OperationMapper
    {
        #region Public
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Operation CreateFrom(this global::Models.DomainModels.Operation source)
        {
            return new Operation
            {
                OperationId = source.OperationId,
                OperationName = source.OperationName,
            };
        }
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static global::Models.DomainModels.Operation CreateFrom(this Operation source)
        {
            if (source != null)
            {
                return new global::Models.DomainModels.Operation
                {
                    OperationId = source.OperationId,
                OperationName = source.OperationName,
                };
            }
            return new global::Models.DomainModels.Operation();
        }
        #endregion
    }
}