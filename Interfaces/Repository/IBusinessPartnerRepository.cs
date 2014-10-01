using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Partner Repository Interface
    /// </summary>
    public interface IBusinessPartnerRepository : IBaseRepository<BusinessPartner, long>
    {
        /// <summary>
        /// Get All business partners
        /// </summary>
        BusinessPartnerSearchResponse GetAllBusinessPartners(BusinessPartnerSearchRequest businessPartnerSearchRequest);
        /// <summary>
        /// Get Busienss partner by Name and Id
        /// </summary>
        BusinessPartner GetBusinessPartnerByName(string name, int id);
        /// <summary>
        /// Get business partner by Id
        /// </summary>
        BusinessPartner GetById(long id);

        /// <summary>
        /// Get business partnere by License No
        /// </summary>
        BusinessPartner GetByLicenseNo(string licenseNo);

        /// <summary>
        /// Get business partnere by Nic No
        /// </summary>
        BusinessPartner GetByNicNo(string nicNo);

        /// <summary>
        /// Get business partnere by Passport No
        /// </summary>
        BusinessPartner GetByPassportNo(string passportNo);

        /// <summary>
        /// Get business partnere by Phone No
        /// </summary>
        BusinessPartner GetByPhoneNo(string phoneNo, Models.CommonTypes.PhoneType phoneType);

        /// <summary>
        /// Association check between BP and Rating Type
        /// </summary>
        bool IsBusinessPartnerAssociatedWithRatingType(long ratingTypeId);

        /// <summary>
        /// Association check between BP and Business Legal Status
        /// </summary>
        bool IsBusinessPartnerAssociatedWithBusinessLegalStatus(long businessLegalStatusId);
    }
}
