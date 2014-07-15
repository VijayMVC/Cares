using Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    public static class BusinessPartnerMapper
    {
        #region Public

        /// <summary>
        ///  Create  web api model from domain model
        /// </summary>
        public static Models.BusinessPartnerListView CreateFrom(this BusinessPartner source)
        {
            return new Models.BusinessPartnerListView
            {
                BusinessPartnerId = source.BusinessPartnerId,
                BusinessPartnerName = source.BusinessPartnerName,
                BusinessPartnerDesciption = source.BusinessPartnerDesciption,
                IsIndividual = source.IsIndividual,          
                BPRatingTypeCode = source.BPRatingType.BpRatingTypeCode,
                BPRatingTypeName = source.BPRatingType.BpRatingTypeName,
                CompanyCode = source.Company.CompanyCode,
                CompanyName = source.Company.CompanyName
            };
           
        }

        /// <summary>
        ///  Create domain model from  web api model
        /// </summary>
        public static BusinessPartner CreateFrom(this Models.BusinessPartnerListView source)
        {
            return new BusinessPartner
            {
                BusinessPartnerId = source.BusinessPartnerId,
                BusinessPartnerName = source.BusinessPartnerName,
                BusinessPartnerDesciption = source.BusinessPartnerDesciption
            };
        }

        #endregion

    }
}
