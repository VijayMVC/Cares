using Models.DomainModels;
namespace Cares.Web.ModelMappers
{
    public static class BusinessPartnerMapper
    {
        #region Public

        /// <summary>
        ///  Create listview web api model from domain model
        /// </summary>
        public static Models.BusinessPartnerListView CreateFrom(this BusinessPartner source)
        {
            return new Models.BusinessPartnerListView
            {
                BusinessPartnerId = source.BusinessPartnerId,
                BusinessPartnerListId = (source.IsIndividual ? "I" : "C") + "-" + source.BusinessPartnerId,
                BusinessPartnerListName = source.BusinessPartnerName,
                BusinessPartnerName = (source.IsIndividual ? "I" : "C") + "-" + source.BusinessPartnerId + '-' + source.BusinessPartnerName,
                IsIndividual = source.IsIndividual ? "Individual" : "Company",
                BPRatingTypeName = source.BPRatingType != null ? source.BPRatingType.BpRatingTypeCode+'-'+source.BPRatingType.BpRatingTypeName : "",
                CompanyName = source.Company.CompanyCode +'-'+source.Company.CompanyName
            };
           
        }

        /// <summary>
        ///  Create detail web api model from domain model
        /// </summary>
        public static Models.BusinessPartnerDetail CreateApiDetailFromDomainModel(this BusinessPartner source)
        {
            return new Models.BusinessPartnerDetail
            {
                BusinessPartnerId = source.BusinessPartnerId,
                BusinessPartnerName = source.BusinessPartnerName,
                BusinessPartnerDesciption = source.BusinessPartnerDesciption,
                IsIndividual = source.IsIndividual,
                BusinessLegalStatusId = source.BusinessLegalStatusId,
                PaymentTermId = source.PaymentTermId,
                BPRatingTypeId = source.BPRatingTypeId,
                BusinessPartnerCode = source.BusinessPartnerCode,
                BusinessPartnerEmailAddress = source.BusinessPartnerEmailAddress,
                BusinessPartnerIsValid = source.BusinessPartnerIsValid,
                CompanyId = source.CompanyId,
                DealingEmployeeId = source.DealingEmployeeId,
                IsSystemGuarantor = source.IsSystemGuarantor,
                NonSystemGuarantor = source.NonSystemGuarantor,
                SystemGuarantorId = source.SystemGuarantorId,
                BusinessPartnerIndividual = source.BusinessPartnerIndividual.CreateFrom()
            };
        }

        /// <summary>
        ///  Create domain model from  web api listview model
        /// </summary>
        public static BusinessPartner CreateFrom(this Models.BusinessPartnerListView source)
        {
            return new BusinessPartner
            {
                BusinessPartnerId = source.BusinessPartnerId,
                BusinessPartnerName = source.BusinessPartnerName,
            };
        }

        /// <summary>
        ///  Create domain model from  web api detail model
        /// </summary>
        public static BusinessPartner CreateFrom(this Models.BusinessPartnerDetail source)
        {
            return new BusinessPartner
            {
                BusinessPartnerId = source.BusinessPartnerId.HasValue ? (long)source.BusinessPartnerId : 0,
                BusinessPartnerName = source.BusinessPartnerName,
                BusinessPartnerDesciption = source.BusinessPartnerDesciption,
                BusinessLegalStatusId = source.BusinessLegalStatusId,
                NonSystemGuarantor = source.NonSystemGuarantor,
                IsIndividual = source.IsIndividual,
                IsSystemGuarantor = source.IsSystemGuarantor,
                SystemGuarantorId = source.SystemGuarantorId,
                PaymentTermId = source.PaymentTermId,
                BPRatingTypeId = source.BPRatingTypeId,
                DealingEmployeeId = source.DealingEmployeeId,
                CompanyId = source.CompanyId,
                BusinessPartnerIsValid = true,
                BusinessPartnerEmailAddress = source.BusinessPartnerEmailAddress,
                BusinessPartnerIndividual = source.BusinessPartnerIndividual.CreateFrom()

            };
        }

        #endregion

    }
}
