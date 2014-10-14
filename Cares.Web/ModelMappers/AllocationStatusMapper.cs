using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Allocation Status Mapper
    /// </summary>
    public static class AllocationStatusMapper
    {
        #region Public

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static AllocationStatus CreateFrom(this Cares.Models.DomainModels.AllocationStatus source)
        {
            return new AllocationStatus
            {
                AllocationStatusId = source.AllocationStatusId,
                AllocationStatusName = source.AllocationStatusName,
                AllocationStatusCode = source.AllocationStatusCode,
                AllocationStatusCodeName = source.AllocationStatusCode + "-" + source.AllocationStatusName,
                AllocationStatusKey = source.AllocationStatusKey
            };
        }

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static Cares.Models.DomainModels.AllocationStatus CreateFrom(this AllocationStatus source)
        {
            return new Cares.Models.DomainModels.AllocationStatus
            {
                AllocationStatusId = source.AllocationStatusId,
                AllocationStatusName = source.AllocationStatusName,
                AllocationStatusCode = source.AllocationStatusCode,
                AllocationStatusKey = source.AllocationStatusKey
            };
        }

        #endregion
    }
}