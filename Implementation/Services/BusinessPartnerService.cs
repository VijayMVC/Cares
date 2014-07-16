using System;
using System.Globalization;
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
                
                businessPartnerRepository.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion

    }
}
