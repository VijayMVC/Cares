using System.Linq;
using Cares.Models.DomainModels;
using Cares.Models.ResponseModels;
using ApiModel = Cares.Web.Models;
using DomainModel = Cares.Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    public static class BusinessPartnerMapper
    {
        #region Business Partner Mappers

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
                BPRatingTypeName = source.BPRatingType != null ? source.BPRatingType.BpRatingTypeCode + '-' + source.BPRatingType.BpRatingTypeName : "",
                CompanyName = source.Company.CompanyCode + '-' + source.Company.CompanyName
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
                BusinessPartnerIndividual = source.BusinessPartnerIndividual.CreateFrom(),
                BusinessPartnerCompany = source.BusinessPartnerCompany.CreateFrom(),
                BusinessPartnerInTypes = source.BusinessPartnerInTypes.Select(x => x.CreateFrom()).ToList(),
                BusinessPartnerPhoneNumbers = source.BusinessPartnerPhoneNumbers.Select(x => x.CreateFrom()).ToList(),
                BusinessPartnerAddressList = source.BusinessPartnerAddressList.Select(x => x.CreateFrom()).ToList(),
                BusinessPartnerMarketingChannels = source.BusinessPartnerMarketingChannels.Select(x=>x.CreateFrom()).ToList()
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
                BusinessPartnerIndividual = source.BusinessPartnerIndividual.CreateFrom(),
                BusinessPartnerCompany = source.BusinessPartnerCompany.CreateFrom(),
                BusinessPartnerInTypes = source.BusinessPartnerInTypes.Select(x => x.CreateFrom()).ToList(),
                BusinessPartnerPhoneNumbers = source.BusinessPartnerPhoneNumbers.Select(x => x.CreateFrom()).ToList(),
                BusinessPartnerAddressList = source.BusinessPartnerAddressList.Select(x=>x.CreateFrom()).ToList(),
                BusinessPartnerMarketingChannels = source.BusinessPartnerMarketingChannels.Select(x=>x.CreateFrom()).ToList()
            };
        }

        #endregion

        #region Business Patner Response Mapper

        /// <summary>
        ///  Create web api model from domain entity
        /// </summary>
        public static Models.BusinessPartnerSearchResponse CreateFrom(this  BusinessPartnerSearchResponse source)
        {
            return new Models.BusinessPartnerSearchResponse
            {
                TotalCount = source.TotalCount,
                BusinessPartners = source.BusinessPartners.Select(p => p.CreateFrom())
            };
        }
        #endregion

        #region Business Partner Base Date Response Mapper

        /// <summary>
        ///  Create web api model from domain entity
        /// </summary>
        public static Models.BusinessPartnerBaseResponse CreateFrom(this BusinessPartnerBaseDataResponse source)
        {
            return new Models.BusinessPartnerBaseResponse
            {
                ResponseBPRatingTypes = source.ResponseBPRatingTypes.Select(x => x.CreateFrom()),
                ResponsePaymentTerms = source.ResponsePaymentTerms.Select(x => x.CreateFrom()),
                ResponseBusinessPartners = source.ResponseBusinessPartners.Select(x => x.CreateFrom()),
                ResponseCompanies = source.ResponseCompanies.Select(x => x.CreateFrom()),
                ResponseDealingEmployees = source.ResponseDealingEmployees.Select(x => x.CreateFrom()),
                ResponseBusinessLegalStatuses = source.ResponseBusinessLegalStatuses.Select(x => x.CreateFrom()),
                ResponseBusinessPartnerCompanies = source.ResponseBusinessPartnerCompanies.Select(x => x.CreateFrom()),
                ResponseOccupationTypes = source.ResponseOccupationTypes.Select(x => x.CreateFrom()),
                ResponseCountries = source.ResponseCountries.Select(x => x.CreateFrom()),
                ResponseBusinessSegments = source.ResponseBusinessSegments.Select(x => x.CreateFrom()),
                ResponseBusinessPartnerSubTypes = source.ResponseBusinessPartnerSubTypes.Select(x => x.CreateFrom()),
                ResponsePhoneTypes = source.ResponsePhoneTypes.Select(x => x.CreateFrom()),
                ResponseAddressTypes = source.ResponseAddressTypes.Select(x=>x.CreateFrom()),
                ResponseMarketingChannels = source.ResponseMarketingChannels.Select(x=>x.CreateFrom())
            };
        }
        #endregion

        #region Business Partner Individual Mappers

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessPartnerIndividual CreateFrom(this BusinessPartnerIndividual source)
        {
            return new ApiModel.BusinessPartnerIndividual
            {
                BusinessPartnerId = source.BusinessPartnerId,
                FirstName = source.FirstName,
                LastName = source.LastName,
                GenderStatus = source.GenderStatus,
                Initials = source.Initials,
                IqamaExpiryDate = source.IqamaExpiryDate,
                DateOfBirth = source.DateOfBirth,
                CompanyAddress = source.CompanyAddress,
                CompanyPhone = source.CompanyPhone,
                BusinessPartnerCompnayId = source.BusinessPartnerCompnayId,
                CompanyName = source.CompanyName,
                TaxRegisterationCode = source.TaxRegisterationCode,
                TaxNumber = source.TaxNumber,
                PassportNumber = source.PassportNumber,
                PassportExpiryDate = source.PassportExpiryDate,
                PassportCountryId = source.PassportCountryId,
                OccupationTypeId = source.OccupationTypeId,
                NicNumber = source.NicNumber,
                NicExpiryDate = source.LiscenseExpiryDate,
                LiscenseNumber = source.LiscenseNumber,
                LiscenseExpiryDate = source.LiscenseExpiryDate,
                MiddleName = source.MiddleName,
                MaritalStatusCode = source.MaritalStatusCode,
                IsCompanyExternal = source.IsCompanyExternal,
                IqamaNo = source.IqamaNo
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static BusinessPartnerIndividual CreateFrom(this ApiModel.BusinessPartnerIndividual source)
        {
            return new BusinessPartnerIndividual
            {
                BusinessPartnerId = source.BusinessPartnerId != null ? (long)source.BusinessPartnerId : 0,
                FirstName = source.FirstName,
                LastName = source.LastName,
                GenderStatus = source.GenderStatus,
                Initials = source.Initials,
                IqamaExpiryDate = source.IqamaExpiryDate,
                DateOfBirth = source.DateOfBirth,
                CompanyAddress = source.CompanyAddress,
                CompanyPhone = source.CompanyPhone,
                BusinessPartnerCompnayId = source.BusinessPartnerCompnayId,
                CompanyName = source.CompanyName,
                TaxRegisterationCode = source.TaxRegisterationCode,
                TaxNumber = source.TaxNumber,
                PassportNumber = source.PassportNumber,
                PassportExpiryDate = source.PassportExpiryDate,
                PassportCountryId = source.PassportCountryId,
                OccupationTypeId = source.OccupationTypeId,
                NicNumber = source.NicNumber,
                NicExpiryDate = source.LiscenseExpiryDate,
                LiscenseNumber = source.LiscenseNumber,
                LiscenseExpiryDate = source.LiscenseExpiryDate,
                MiddleName = source.MiddleName,
                MaritalStatusCode = source.MaritalStatusCode,
                IsCompanyExternal = source.IsCompanyExternal,
                IqamaNo = source.IqamaNo
            };
        }

        #endregion

        #region Business Partner Company Mappers

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessPartnerCompany CreateFrom(this BusinessPartnerCompany source)
        {
            return new ApiModel.BusinessPartnerCompany
            {
                BusinessPartnerId = source.BusinessPartnerId,
                BusinessPartnerCompanyCode = source.BusinessPartnerCompanyCode,
                BusinessPartnerCompanyName = source.BusinessPartnerCompanyName,
                BusinessSegmentId = source.BusinessSegmentId,
                AccountNumber = source.AccountNumber,
                EstablishedSince = source.EstablishedSince,
                SwiftCode = source.SwiftCode
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static BusinessPartnerCompany CreateFrom(this ApiModel.BusinessPartnerCompany source)
        {
            return new BusinessPartnerCompany
            {
                BusinessPartnerId = source.BusinessPartnerId != null ? (long)source.BusinessPartnerId : 0,
                BusinessPartnerCompanyCode = source.BusinessPartnerCompanyCode,
                BusinessPartnerCompanyName = source.BusinessPartnerCompanyName,
                BusinessSegmentId = source.BusinessSegmentId,
                AccountNumber = source.AccountNumber,
                EstablishedSince = source.EstablishedSince,
                SwiftCode = source.SwiftCode
            };
        }

        #endregion

        #region Business Partner SubType Mappers

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessPartnerSubTypeDropDown CreateFrom(this BusinessPartnerSubType source)
        {
            return new ApiModel.BusinessPartnerSubTypeDropDown
            {
                BusinessPartnerSubTypeId = source.BusinessPartnerSubTypeId,
                BusinessPartnerSubTypeCodeName = source.BusinessPartnerSubTypeCode + " - " + source.BusinessPartnerSubTypeName,
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static BusinessPartnerSubType CreateFrom(this ApiModel.BusinessPartnerSubTypeDropDown source)
        {
            return new BusinessPartnerSubType
            {
                BusinessPartnerSubTypeId = source.BusinessPartnerSubTypeId,
                BusinessPartnerSubTypeName = source.BusinessPartnerSubTypeCodeName
            };
        }

        #endregion

        #region Business Partner InType Mappers

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessPartnerInType CreateFrom(this BusinessPartnerInType source)
        {
            return new ApiModel.BusinessPartnerInType
                   {
                       BusinessPartnerInTypeId = source.BusinessPartnerInTypeId,
                       BusinessPartnerInTypeDescription = source.BusinessPartnerInTypeDescription,
                       BusinessPartnerSubTypeId = source.BusinessPartnerSubTypeId,
                       BusinessPartnerSubTypeName =
                           source.BusinessPartnerSubType != null
                               ? (source.BusinessPartnerSubType.BusinessPartnerSubTypeCode + '-' +
                                  source.BusinessPartnerSubType.BusinessPartnerSubTypeName)
                               : string.Empty,
                       FromDate = source.FromDate,
                       ToDate = source.ToDate,
                       BusinessPartnerId = source.BusinessPartnerId > 0 ? source.BusinessPartnerId : 0,
                       BpRatingTypeId = source.BpRatingTypeId,
                       BpRatingTypeName =
                           source.BpRatingType != null
                               ? (source.BpRatingType.BpRatingTypeCode + '-' + source.BpRatingType.BpRatingTypeName)
                               : string.Empty
                   };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static BusinessPartnerInType CreateFrom(this ApiModel.BusinessPartnerInType source)
        {
            return new BusinessPartnerInType
            {
                BusinessPartnerInTypeId = source.BusinessPartnerInTypeId != null ? (long)source.BusinessPartnerInTypeId : 0,
                BusinessPartnerInTypeDescription = source.BusinessPartnerInTypeDescription,
                BusinessPartnerSubTypeId = source.BusinessPartnerSubTypeId,
                FromDate = source.FromDate,
                ToDate = source.ToDate,
                BusinessPartnerId =source.BusinessPartnerId != null ? (long) source.BusinessPartnerId : 0,
                BpRatingTypeId = source.BpRatingTypeId
            };
        }

        #endregion

        #region Business Partner Marketing Channel Mappers

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessPartnerMarketingChannel CreateFrom(this BusinessPartnerMarketingChannel source)
        {
            return new ApiModel.BusinessPartnerMarketingChannel()
            {
                BusinessPartnerMarketingChannelId = source.BusinessPartnerMarketingChannelId,
                MarketingChannelId = source.MarketingChannelId,
                MarketingChannelName = source.MarketingChannel != null ? (source.MarketingChannel.MarketingChannelCode+ "-"+source.MarketingChannel.MarketingChannelName):string.Empty,
                BusinessPartnerId = source.BusinessPartnerId
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static BusinessPartnerMarketingChannel CreateFrom(this ApiModel.BusinessPartnerMarketingChannel source)
        {
            return new BusinessPartnerMarketingChannel
            {
                BusinessPartnerMarketingChannelId = source.BusinessPartnerMarketingChannelId != null ? (long)source.BusinessPartnerMarketingChannelId : 0 ,
                MarketingChannelId = source.MarketingChannelId,
                BusinessPartnerId = source.BusinessPartnerId != null ? (long)source.BusinessPartnerId : 0
            };
        }

        #endregion

    }
}
