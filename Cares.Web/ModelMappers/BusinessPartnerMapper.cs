using System;
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
        ///  Create domain model from  web api listview model
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

        /// <summary>
        ///  Create domain model from  web api detail model
        /// </summary>
        public static BusinessPartner CreateFrom(this Models.BusinessPartnerDetail source)
        {
            return new BusinessPartner
            {
                BusinessPartnerId = source.BusinessPartnerId.HasValue ? (long)source.BusinessPartnerId :0,
                BusinessPartnerName = source.BusinessPartnerName,
                BusinessPartnerDesciption = source.BusinessPartnerDesciption,
                IsIndividual = source.IsIndividual,
                IsSystemGuarantor = source.IsSystemGuarantor,
                SystemGuarantorId = source.SystemGuarantorId.HasValue ?source.SystemGuarantorId : 0,
                PaymentTermId = source.PaymentTermId,
                BPRatingTypeId = source.BPRatingTypeId,
                DealingEmployeeId = source.DealingEmployeeId,
                CompanyId = source.CompanyId,
                BusinessPartnerIsValid = true,
                BusinessPartnerCode = "BP-Screen",
                BusinessPartnerEmailAddress = source.BusinessPartnerEmailAddress,
                IsActive = true,
                IsDeleted = false,
                IsPrivate = false,
                IsReadOnly = false,
                RecCreatedDt = DateTime.Now,
                RecLastUpdatedDt = DateTime.Now,
                RecCreatedBy = "zain",
                RecLastUpdatedBy = "zain",
                RowVersion = 0
            };
        }

        #endregion

    }
}
