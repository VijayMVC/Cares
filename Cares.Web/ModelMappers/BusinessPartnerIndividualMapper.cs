using ApiModel = Cares.Web.Models;
using DomainModel = Models.DomainModels;

namespace Cares.Web.ModelMappers
{
    /// <summary>
    /// Business Partner Individual Mapper
    /// </summary>
    public static class BusinessPartnerIndividualMapper
    {
        #region Public
        #region Entity To Model
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
        #endregion
        #region Model To Entity
        /// <summary>
        ///  Create entity from web model
        /// </summary>
        public static DomainModel.BusinessPartnerIndividual CreateFrom(this ApiModel.BusinessPartnerIndividual source)
        {
            return new DomainModel.BusinessPartnerIndividual
            {
                BusinessPartnerId =source.BusinessPartnerId != null ? (long)source.BusinessPartnerId: 0,
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
        #endregion
    }
}