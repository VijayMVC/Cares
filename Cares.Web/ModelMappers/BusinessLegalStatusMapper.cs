
using DomainModels = Cares.Models.DomainModels;
using Cares.Web.Models;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Business Legal Status Mapper
    /// </summary>
    public static class BusinessLegalStatusMapper
    {
        #region Public
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static BusinessLegalStatus CreateFrom(this DomainModels.BusinessLegalStatus source)
        {
            return new BusinessLegalStatus
            {
                BusinessLegalStatusId = source.BusinessLegalStatusId,
                BusinessLegalStatusName = source.BusinessLegalStatusName
            };
        }
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModels.BusinessLegalStatus CreateFrom(this BusinessLegalStatus source)
        {
            if (source != null)
            {
                return new DomainModels.BusinessLegalStatus
                {
                    BusinessLegalStatusId = source.BusinessLegalStatusId,
                    BusinessLegalStatusName = source.BusinessLegalStatusName
                };
            }
            return new DomainModels.BusinessLegalStatus();
        }
        #endregion
    }
}