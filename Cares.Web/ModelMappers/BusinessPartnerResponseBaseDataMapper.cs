using System.Linq;
using Models.ResponseModels;
namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Business Partner Response Base Data Mapper
    /// </summary>
    public static class  BusinessPartnertResponseBaseDataMapper
    {
        #region Public

        /// <summary>
        ///  Create web api model from domain entity
        /// </summary>
        public static Models.BusinessPartnerBaseResponse CreateFrom(this BusinessPartnerBaseDataResponse source)
        {
            return new Models.BusinessPartnerBaseResponse
            {
                ResponseBPRatingTypes = source.ResponseBPRatingTypes.Select(x => x.CreateFrom()),
                ResponsePaymentTerms = source.ResponsePaymentTerms.Select(x=>x.CreateFrom()),
                ResponseBusinessPartners = source.ResponseBusinessPartners.Select(x => x.CreateFrom()),
                ResponseCompanies = source.ResponseCompanies.Select(x => x.CreateFrom()),
                ResponseDealingEmployees = source.ResponseDealingEmployees.Select(x=>x.CreateFrom()),
                ResponseBusinessLegalStatuses = source.ResponseBusinessLegalStatuses.Select(x => x.CreateFrom())
            };
        }
        #endregion

    }
}
