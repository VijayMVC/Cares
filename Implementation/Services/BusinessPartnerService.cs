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
    /// Business Partner Service
    /// </summary>
    public class BusinessPartnerService : IBusinessPartnerService
    {
        #region Private
        private readonly IBusinessPartnerRepository businessPartnerRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerService(IBusinessPartnerRepository businessPartnerRepository)
        {
            this.businessPartnerRepository = businessPartnerRepository;

        }
        #endregion

        #region Public
        /// <summary>
        /// Load All Business Partners
        /// </summary>
        public BusinessPartnerResponse LoadAllBusinessPartners(BusinessPartnerSearchRequest businessPartnerSearchRequest)
        {
           return businessPartnerRepository.GetAllBusinessPartners(businessPartnerSearchRequest);
        }
        /// <summary>
        /// Find business partner by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessPartner FindBusinessPartner(int id)
        {
            return businessPartnerRepository.Find(id);
        }
        /// <summary>
        /// Delete Business Partner
        /// </summary>
        /// <param name="businessPartner"></param>
        public void DeleteBusinessPartner(BusinessPartner businessPartner)
        {
            BusinessPartner businessPartnerDbVersion = FindBusinessPartner((int)businessPartner.BusinessPartnerId);
            if (businessPartnerDbVersion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Business Partner with Id {0} not found!", businessPartner.BusinessPartnerId));
            }
            businessPartnerRepository.Delete(businessPartnerDbVersion);
            businessPartnerRepository.SaveChanges();
        }
        /// <summary>
        /// Add business partner
        /// </summary>
        /// <param name="businessPartner"></param>
        /// <returns></returns>
        public bool AddBusinessPartner(BusinessPartner businessPartner)
        {
            if (ValidateBusinessPartner(businessPartner))
            {
                businessPartner.BusinessPartnerCode = "BP-Screen";
                businessPartner.UserDomainKey = businessPartnerRepository.UserDomainKey;
                businessPartner.IsActive = true;
                businessPartner.IsDeleted = false;
                businessPartner.IsPrivate = false;
                businessPartner.IsReadOnly = false;
                businessPartner.RecCreatedDt = DateTime.Now;
                businessPartner.RecLastUpdatedDt = DateTime.Now;
                businessPartner.RecCreatedBy = businessPartnerRepository.LoggedInUserIdentity;
                businessPartner.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                businessPartner.RowVersion = 0;

                businessPartnerRepository.Add(businessPartner);
                businessPartnerRepository.SaveChanges();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Validate Business Partner
        /// </summary>
        /// <param name="businessPartner"></param>
        /// <returns></returns>
        private bool ValidateBusinessPartner(BusinessPartner businessPartner)
        {
            BusinessPartner businessPartnerDbVersion = businessPartnerRepository.GetBusinessPartnerByName(businessPartner.BusinessPartnerName, (int)businessPartner.BusinessPartnerId);
            return businessPartnerDbVersion == null;
        }
        /// <summary>
        /// Update business partner
        /// </summary>
        /// <param name="businessPartner"></param>
        /// <returns></returns>
        public bool UpdateBusinessPartner(BusinessPartner businessPartner)
        {
            BusinessPartner businessPartnerDbVersion = FindBusinessPartner((int)businessPartner.BusinessPartnerId);
            if (businessPartnerDbVersion != null)
            {
                businessPartnerDbVersion.BusinessPartnerName = businessPartner.BusinessPartnerName;
                businessPartnerDbVersion.BusinessPartnerDesciption = businessPartner.BusinessPartnerDesciption;
                businessPartnerDbVersion.IsSystemGuarantor = businessPartner.IsSystemGuarantor;
                businessPartnerDbVersion.NonSystemGuarantor = businessPartner.NonSystemGuarantor;
                businessPartnerDbVersion.IsIndividual = businessPartner.IsIndividual;
                businessPartnerDbVersion.BusinessPartnerEmailAddress = businessPartner.BusinessPartnerEmailAddress;
                businessPartnerDbVersion.CompanyId = businessPartner.CompanyId;
                businessPartnerDbVersion.SystemGuarantorId = businessPartner.SystemGuarantorId;
                businessPartnerDbVersion.BusinessLegalStatusId = businessPartner.BusinessLegalStatusId;
                businessPartnerDbVersion.DealingEmployeeId = businessPartner.DealingEmployeeId;
                businessPartnerDbVersion.PaymentTermId = businessPartner.PaymentTermId;
                businessPartnerDbVersion.BPRatingTypeId = businessPartner.BPRatingTypeId;

                businessPartnerDbVersion.RecLastUpdatedDt = DateTime.Now;
                businessPartnerDbVersion.RecCreatedBy = "zain";
                businessPartnerDbVersion.RowVersion = businessPartnerDbVersion.RowVersion + 1;

                businessPartnerRepository.SaveChanges();
                return true;
            }

            return false;
        }
        /// <summary>
        /// Get Business Partner by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessPartner FindBusinessPartnerById(long id)
        {
            return businessPartnerRepository.GetById(id);
        }
        #endregion



        
    }
}
