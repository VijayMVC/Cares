using Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    public static class BusinessPartnerMapper
    {
        #region Public

        /// <summary>
        ///  Create  web api model from domain model
        /// </summary>
        public static Models.BusinessPartner CreateFrom(this BusinessPartner source)
        {
            return new Models.BusinessPartner
            {
                BusinessPartnerId = source.BusinessPartnerId,
                BusinessPartnerName = source.BusinessPartnerName,
                BusinessPartnerDesciption = source.BusinessPartnerDesciption
            };
           
        }

        /// <summary>
        ///  Create domain model from  web api model
        /// </summary>
        public static BusinessPartner CreateFrom(this Models.BusinessPartner source)
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
