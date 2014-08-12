
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
        public static BusinessLegalStatusDropDown CreateFrom(this DomainModels.BusinessLegalStatus source)
        {
            return new BusinessLegalStatusDropDown
            {
                BusinessLegalStatusId = source.BusinessLegalStatusId,
                BusinessLegalStatusCodeName = source.BusinessLegalStatusCode + " - " + source.BusinessLegalStatusName
            };
        }
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModels.BusinessLegalStatus CreateFrom(this BusinessLegalStatusDropDown source)
        {
            if (source != null)
            {
                return new DomainModels.BusinessLegalStatus
                {
                    BusinessLegalStatusId = source.BusinessLegalStatusId,
                    BusinessLegalStatusName = source.BusinessLegalStatusCodeName
                };
            }
            return new DomainModels.BusinessLegalStatus();
        }
        #endregion
    }
}