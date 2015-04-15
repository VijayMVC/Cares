using System;
using System.Globalization;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Business Partner individual Service
    /// </summary>
    public class BusinessPartnerIndividualService : IBusinessPartnerIndividualService
    {
        #region Private
        private readonly IBusinessPartnerIndividualRepository businessPartnerIndividualRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerIndividualService(IBusinessPartnerIndividualRepository businessPartnerIndividualRepository)
        {
            this.businessPartnerIndividualRepository = businessPartnerIndividualRepository;

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
        public BusinessPartnerIndividual FindBusinessPartnerIndividual(int id)
        {
            return businessPartnerIndividualRepository.Find(id);
        }
        /// <summary>
        /// Delete Business Partner individual
        /// </summary>
        /// <param name="businessPartnerIndividual"></param>
        public void DeleteBusinessPartnerIndividual(BusinessPartnerIndividual businessPartnerIndividual)
        {
            BusinessPartnerIndividual businessPartnerIndividualDbVersion = FindBusinessPartnerIndividual((int)businessPartnerIndividual.BusinessPartnerId);
            if (businessPartnerIndividualDbVersion == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.BusinessPartner.BusinessPartner.BPNotFound));
            }
            businessPartnerIndividualRepository.Delete(businessPartnerIndividualDbVersion);
            businessPartnerIndividualRepository.SaveChanges();
        }
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
        /// <summary>
        /// Validate Business Partner
        /// </summary>
        /// <param name="businessPartner"></param>
        /// <returns></returns>
        private bool ValidateBusinessPartner(BusinessPartnerIndividual businessPartnerIndividual)
        {
            BusinessPartnerIndividual businessPartnerIndividualDbVersion = businessPartnerIndividualRepository.GetBusinessPartnerIndividualByName(businessPartnerIndividual.FirstName, (int)businessPartnerIndividual.BusinessPartnerId);
            return businessPartnerIndividualDbVersion == null;
        }
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
        /// Get Business Partner individual by Business Partner Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BusinessPartnerIndividual FindBusinessPartnerIndividualById(long id)
        {
            return businessPartnerIndividualRepository.GetById(id);
        }
        #endregion



        
    }
}
