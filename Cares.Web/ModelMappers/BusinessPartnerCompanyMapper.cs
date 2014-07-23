using ApiModel = Cares.Web.Models;
using DomainModel = Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Business Partner Company Mapper
    /// </summary>
    public static class BusinessPartnerCompanyMapper
    {
        #region Public
        #region Entity To Model
        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessPartnerCompany CreateFrom(this DomainModel.BusinessPartnerCompany source)
            {
                return new ApiModel.BusinessPartnerCompany
                {
                    BusinessPartnerCompanyId = source.BusinessPartnerCompanyId,
                    BusinessPartnerCompanyCode = source.BusinessPartnerCompanyCode,
                    BusinessPartnerCompanyName = source.BusinessPartnerCompanyName
                };
            }
        #endregion
        #region Model To Entity
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModel.BusinessPartnerCompany CreateFrom(this ApiModel.BusinessPartnerCompany source)
        {
            return new DomainModel.BusinessPartnerCompany
            {
                BusinessPartnerCompanyId = source.BusinessPartnerCompanyId,
                BusinessPartnerCompanyCode = source.BusinessPartnerCompanyCode,
                BusinessPartnerCompanyName = source.BusinessPartnerCompanyName
            };
        }
        
        #endregion
        #endregion
    }
}