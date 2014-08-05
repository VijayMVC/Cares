using System.Linq;
using Models.DomainModels;
using ApiModel = Cares.Web.Models;
using DomainModel = Models.DomainModels;
using ResponseModel = Models.ResponseModels;
using RequestModel = Models.RequestModels;

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
                BusinessPartnerIndividual = source.BusinessPartnerIndividual.CreateFrom(),
                BusinessPartnerCompany = source.BusinessPartnerCompany.CreateFrom(),
                BusinessPartnerInTypes = source.BusinessPartnerInTypes.Select(x=>x.CreateFrom()).ToList()
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
                BusinessPartnerCompany =  source.BusinessPartnerCompany.CreateFrom(),
                BusinessPartnerInTypes = source.BusinessPartnerInTypes.Select(x=>x.CreateFrom()).ToList()
            };
        }

        #endregion

        #region Business Patner Response Mapper

        /// <summary>
        ///  Create web api model from domain entity
        /// </summary>
        public static Models.BusinessPartnerResponse CreateFrom(this  ResponseModel.BusinessPartnerResponse source)
        {
            return new Models.BusinessPartnerResponse
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
        public static Models.BusinessPartnerBaseResponse CreateFrom(this ResponseModel.BusinessPartnerBaseDataResponse source)
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
                ResponsePassportCountries = source.ResponsePassportCountries.Select(x => x.CreateFrom()),
                ResponseBusinessSegments = source.ResponseBusinessSegments.Select(x => x.CreateFrom()),
                ResponseBusinessPartnerSubTypes = source.ResponseBusinessPartnerSubTypes.Select(x=>x.CreateFrom()),
                ResponsePhoneTypes = source.ResponsePhoneTypes.Select(x=>x.CreateFrom())
            };
        }
        #endregion

        #region Business Partner Individual Mappers

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessPartnerIndividual CreateFrom(this DomainModel.BusinessPartnerIndividual source)
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
        public static DomainModel.BusinessPartnerIndividual CreateFrom(this ApiModel.BusinessPartnerIndividual source)
        {
            return new DomainModel.BusinessPartnerIndividual
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
        public static ApiModel.BusinessPartnerCompany CreateFrom(this DomainModel.BusinessPartnerCompany source)
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
        public static DomainModel.BusinessPartnerCompany CreateFrom(this ApiModel.BusinessPartnerCompany source)
        {
            return new DomainModel.BusinessPartnerCompany
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
        public static ApiModel.BusinessPartnerSubType CreateFrom(this DomainModel.BusinessPartnerSubType source)
        {
            return new ApiModel.BusinessPartnerSubType
            {
                BusinessPartnerSubTypeId = source.BusinessPartnerSubTypeId,
                BusinessPartnerSubTypeCode = source.BusinessPartnerSubTypeCode,
                BusinessPartnerSubTypeName = source.BusinessPartnerSubTypeCode +'-'+ source.BusinessPartnerSubTypeName,
                BusinessPartnerSubTypeCustomId = source.BusinessPartnerSubTypeId.ToString() + '-' + source.BusinessPartnerSubTypeCode + '-' + source.BusinessPartnerSubTypeName
            };
        }

        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModel.BusinessPartnerSubType CreateFrom(this ApiModel.BusinessPartnerSubType source)
        {
            return new DomainModel.BusinessPartnerSubType
            {
                BusinessPartnerSubTypeId = source.BusinessPartnerSubTypeId,
                BusinessPartnerSubTypeCode = source.BusinessPartnerSubTypeCode,
                BusinessPartnerSubTypeName = source.BusinessPartnerSubTypeName
            };
        }

        #endregion

        #region Business Partner InType Mappers

        /// <summary>
        ///  Create web model from entity
        /// </summary>
        public static ApiModel.BusinessPartnerInType CreateFrom(this DomainModel.BusinessPartnerInType source)
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
                       BusinessPartnerId = source.BusinessPartnerId > 0 ? (long) source.BusinessPartnerId : 0,
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
        public static DomainModel.BusinessPartnerInType CreateFrom(this ApiModel.BusinessPartnerInType source)
        {
            return new DomainModel.BusinessPartnerInType
            {
                BusinessPartnerInTypeId =source.BusinessPartnerInTypeId != null ? (long) source.BusinessPartnerInTypeId : 0,
                BusinessPartnerInTypeDescription = source.BusinessPartnerInTypeDescription,
                BusinessPartnerSubTypeId = source.BusinessPartnerSubTypeId,
                FromDate = source.FromDate,
                ToDate = source.ToDate,
                BusinessPartnerId = source.BusinessPartnerId,
                BpRatingTypeId = source.BpRatingTypeId
           };
        }

        #endregion
    }
}
