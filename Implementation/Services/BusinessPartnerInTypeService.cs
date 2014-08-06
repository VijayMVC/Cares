using System;
using System.Globalization;
using FaceSharp.Api.Objects;
using Interfaces.IServices;
using Interfaces.Repository;
using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;

namespace Implementation.Services
{
    /// <summary>
    /// Business Partner InType Service
    /// </summary>
    public class BusinessPartnerInTypeService : IBusinessPartnerInTypeService
    {
        #region Private
        private readonly IBusinessPartnerInTypeRepository businessPartnerInTypeRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerInTypeService(IBusinessPartnerInTypeRepository businessPartnerInTypeRepository)
        {
            this.businessPartnerInTypeRepository = businessPartnerInTypeRepository;

        }
        #endregion

        #region Public
        ///// <summary>
        ///// Load All Business Partners
        ///// </summary>
        //public BusinessPartnerResponse LoadAllBusinessPartners(BusinessPartnerSearchRequest businessPartnerSearchRequest)
        //{
        //    return businessPartnerIndividualRepository.GetAllBusinessPartners(businessPartnerSearchRequest);
        //}
        /// <summary>
        /// Find business partner individaul by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessPartnerInType FindBusinessPartnerIndividual(int id)
        {
            return businessPartnerInTypeRepository.Find(id);
        }
        ///// <summary>
        ///// Delete Business Partner individual
        ///// </summary>
        ///// <param name="businessPartnerIndividual"></param>
        //public void DeleteBusinessPartnerIndividual(BusinessPartnerInType businessPartnerIndividual)
        //{
        //    BusinessPartnerInType businessPartnerIndividualDbVersion = FindBusinessPartnerIndividual((int)businessPartnerIndividual.BusinessPartnerId);
        //    if (businessPartnerIndividualDbVersion == null)
        //    {
        //        throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Business Partner with Id {0} not found!", businessPartnerIndividual.BusinessPartnerId));
        //    }
        //    businessPartnerInTypeRepository.Delete(businessPartnerIndividualDbVersion);
        //    businessPartnerInTypeRepository.SaveChanges();
        //}
        ///// <summary>
        ///// Add business partner
        ///// </summary>
        ///// <param name="businessPartner"></param>
        ///// <returns></returns>
        //public bool AddBusinessPartner(BusinessPartner businessPartner)
        //{
        //    if (ValidateBusinessPartner(businessPartner))
        //    {
        //        businessPartner.BusinessPartnerCode = "BP-Screen";
        //        businessPartner.UserDomainKey = businessPartnerRepository.UserDomainKey;
        //        businessPartner.IsActive = true;
        //        businessPartner.IsDeleted = false;
        //        businessPartner.IsPrivate = false;
        //        businessPartner.IsReadOnly = false;
        //        businessPartner.RecCreatedDt = DateTime.Now;
        //        businessPartner.RecLastUpdatedDt = DateTime.Now;
        //        businessPartner.RecCreatedBy = businessPartnerRepository.LoggedInUserIdentity;
        //        businessPartner.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
        //        businessPartner.RowVersion = 0;

        //        businessPartnerIndividualRepository.Add(businessPartner);
        //        businessPartnerIndividualRepository.SaveChanges();
        //        return true;
        //    }
        //    return false;
        //}
        ///// <summary>
        ///// Validate Business Partner
        ///// </summary>
        ///// <param name="businessPartner"></param>
        ///// <returns></returns>
        //private bool ValidateBusinessPartner(BusinessPartnerInType businessPartnerIndividual)
        //{
        //    BusinessPartnerInType businessPartnerIndividualDbVersion = businessPartnerInTypeRepository.GetBusinessPartnerIndividualByName(businessPartnerIndividual.FirstName, (int)businessPartnerIndividual.BusinessPartnerId);
        //    return businessPartnerIndividualDbVersion == null;
        //}
        ///// <summary>
        ///// Update business partner
        ///// </summary>
        ///// <param name="businessPartner"></param>
        ///// <returns></returns>
        //public bool UpdateBusinessPartner(BusinessPartner businessPartner)
        //{
        //    BusinessPartner businessPartnerDbVersion = FindBusinessPartner((int)businessPartner.BusinessPartnerId);
        //    if (businessPartnerDbVersion != null)
        //    {
        //        businessPartnerDbVersion.BusinessPartnerName = businessPartner.BusinessPartnerName;
        //        businessPartnerDbVersion.BusinessPartnerDesciption = businessPartner.BusinessPartnerDesciption;
        //        businessPartnerDbVersion.IsSystemGuarantor = businessPartner.IsSystemGuarantor;
        //        businessPartnerDbVersion.NonSystemGuarantor = businessPartner.NonSystemGuarantor;
        //        businessPartnerDbVersion.IsIndividual = businessPartner.IsIndividual;
        //        businessPartnerDbVersion.BusinessPartnerEmailAddress = businessPartner.BusinessPartnerEmailAddress;
        //        businessPartnerDbVersion.CompanyId = businessPartner.CompanyId;
        //        businessPartnerDbVersion.SystemGuarantorId = businessPartner.SystemGuarantorId;
        //        businessPartnerDbVersion.BusinessLegalStatusId = businessPartner.BusinessLegalStatusId;
        //        businessPartnerDbVersion.DealingEmployeeId = businessPartner.DealingEmployeeId;
        //        businessPartnerDbVersion.PaymentTermId = businessPartner.PaymentTermId;
        //        businessPartnerDbVersion.BPRatingTypeId = businessPartner.BPRatingTypeId;

        //        businessPartnerDbVersion.RecLastUpdatedDt = DateTime.Now;
        //        businessPartnerDbVersion.RecCreatedBy = "zain";
        //        businessPartnerDbVersion.RowVersion = businessPartnerDbVersion.RowVersion + 1;

        //        businessPartnerIndividualRepository.SaveChanges();
        //        return true;
        //    }

        //    return false;
        //}
        /// <summary>
        /// Get Business Partner inType by Business Partner Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessPartnerInType FindBusinessPartnerInTypeById(long id)
        {
            return businessPartnerInTypeRepository.GetById(id);
        }
        #endregion
 
    }
}
