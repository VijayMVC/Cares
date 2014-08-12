using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Business Partner Service
    /// </summary>
    public class BusinessPartnerService : IBusinessPartnerService
    {
        #region Private
        private readonly IBusinessPartnerRepository businessPartnerRepository;
        private readonly IBusinessPartnerInTypeRepository businessPartnerInTypeRepository;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public BusinessPartnerService(IBusinessPartnerRepository businessPartnerRepository, IBusinessPartnerInTypeRepository businessPartnerInTypeRepository)
        {
            if (businessPartnerInTypeRepository == null)
                throw new ArgumentNullException("businessPartnerInTypeRepository");

            this.businessPartnerRepository = businessPartnerRepository;
            this.businessPartnerInTypeRepository = businessPartnerInTypeRepository;
        }

        #endregion

        #region Public
        /// <summary>
        /// Load All Business Partners
        /// </summary>
        public BusinessPartnerSearchResponse LoadAllBusinessPartners(BusinessPartnerSearchRequest businessPartnerSearchRequest)
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
                //set master (business partner) properties
                #region Business Partner
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
                #endregion

                //set child (business partner individual) properties
                #region Business Partner Individual
                businessPartner.BusinessPartnerIndividual.RecCreatedBy =
                    businessPartner.BusinessPartnerIndividual.RecLastUpdatedBy =
                        businessPartnerRepository.LoggedInUserIdentity;
                businessPartner.BusinessPartnerIndividual.RecCreatedDt =
                    businessPartner.BusinessPartnerIndividual.RecLastUpdatedDt =
                        DateTime.Now;
                businessPartner.BusinessPartnerIndividual.UserDomainKey = businessPartnerRepository.UserDomainKey;
                #endregion

                //set child (business partner company) properties
                #region Business Partner Company
                businessPartner.BusinessPartnerCompany.RecCreatedBy =
                    businessPartner.BusinessPartnerCompany.RecLastUpdatedBy =
                        businessPartnerRepository.LoggedInUserIdentity;
                businessPartner.BusinessPartnerCompany.RecCreatedDt =
                    businessPartner.BusinessPartnerCompany.RecLastUpdatedDt =
                        DateTime.Now;
                businessPartner.BusinessPartnerCompany.UserDomainKey = businessPartnerRepository.UserDomainKey;
                #endregion

                //set child (business partner intypes) properties
                #region Business Partner Intypes
                // set user domain key
                foreach (BusinessPartnerInType item in businessPartner.BusinessPartnerInTypes)
                {
                    item.UserDomainKey = businessPartnerRepository.UserDomainKey;
                }
                #endregion

                //set child (business partner phones) properties
                #region Business Partner Phones
                // set properties
                foreach (Phone item in businessPartner.BusinessPartnerPhoneNumbers)
                {
                    item.IsActive = true;
                    item.IsDeleted = false;
                    item.IsPrivate = false;
                    item.IsReadOnly = false;
                    item.RecCreatedDt = DateTime.Now;
                    item.RecLastUpdatedDt = DateTime.Now;
                    item.RecCreatedBy = businessPartnerRepository.LoggedInUserIdentity;
                    item.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                    item.RowVersion = 0;
                    item.UserDomainKey = businessPartnerRepository.UserDomainKey;
                }
                #endregion

                //set child (business partner address) properties
                #region Business Partner Address
                // set properties
                foreach (Address item in businessPartner.BusinessPartnerAddressList)
                {
                    item.IsActive = true;
                    item.IsDeleted = false;
                    item.IsPrivate = false;
                    item.IsReadOnly = false;
                    item.RecCreatedDt = DateTime.Now;
                    item.RecLastUpdatedDt = DateTime.Now;
                    item.RecCreatedBy = businessPartnerRepository.LoggedInUserIdentity;
                    item.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                    item.RowVersion = 0;
                    item.UserDomainKey = businessPartnerRepository.UserDomainKey;
                }
                #endregion

                //set child (business partner marketing channel) properties
                #region Business Partner Marketing Channel
                // set properties
                foreach (BusinessPartnerMarketingChannel item in businessPartner.BusinessPartnerMarketingChannels)
                {
                    item.RecCreatedDt = DateTime.Now;
                    item.RecLastUpdatedDt = DateTime.Now;
                    item.RecCreatedBy = businessPartnerRepository.LoggedInUserIdentity;
                    item.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                    item.RowVersion = 0;
                    item.UserDomainKey = businessPartnerRepository.UserDomainKey;
                }
                #endregion

                // save data
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
                //set master(business partner) properties
                #region Business Partner
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
                businessPartnerDbVersion.RecCreatedBy = businessPartnerRepository.LoggedInUserIdentity;
                businessPartnerDbVersion.RowVersion = businessPartnerDbVersion.RowVersion + 1;
                #endregion

                //set child (buiness partner individual properties)
                #region Business Partner Individual
                businessPartnerDbVersion.BusinessPartnerIndividual.BusinessPartnerId = businessPartner.BusinessPartnerIndividual.BusinessPartnerId;
                businessPartnerDbVersion.BusinessPartnerIndividual.FirstName = businessPartner.BusinessPartnerIndividual.FirstName;
                businessPartnerDbVersion.BusinessPartnerIndividual.MiddleName = businessPartner.BusinessPartnerIndividual.MiddleName;
                businessPartnerDbVersion.BusinessPartnerIndividual.LastName = businessPartner.BusinessPartnerIndividual.LastName;
                businessPartnerDbVersion.BusinessPartnerIndividual.Initials = businessPartner.BusinessPartnerIndividual.Initials;
                businessPartnerDbVersion.BusinessPartnerIndividual.GenderStatus = businessPartner.BusinessPartnerIndividual.GenderStatus;
                businessPartnerDbVersion.BusinessPartnerIndividual.MaritalStatusCode = businessPartner.BusinessPartnerIndividual.MaritalStatusCode;
                businessPartnerDbVersion.BusinessPartnerIndividual.OccupationTypeId = businessPartner.BusinessPartnerIndividual.OccupationTypeId;
                businessPartnerDbVersion.BusinessPartnerIndividual.LastName = businessPartner.BusinessPartnerIndividual.LastName;
                businessPartnerDbVersion.BusinessPartnerIndividual.DateOfBirth = businessPartner.BusinessPartnerIndividual.DateOfBirth;
                businessPartnerDbVersion.BusinessPartnerIndividual.NicNumber = businessPartner.BusinessPartnerIndividual.NicNumber;
                businessPartnerDbVersion.BusinessPartnerIndividual.NicExpiryDate = businessPartner.BusinessPartnerIndividual.NicExpiryDate;
                businessPartnerDbVersion.BusinessPartnerIndividual.IqamaNo = businessPartner.BusinessPartnerIndividual.IqamaNo;
                businessPartnerDbVersion.BusinessPartnerIndividual.IqamaExpiryDate = businessPartner.BusinessPartnerIndividual.IqamaExpiryDate;
                businessPartnerDbVersion.BusinessPartnerIndividual.PassportNumber = businessPartner.BusinessPartnerIndividual.PassportNumber;
                businessPartnerDbVersion.BusinessPartnerIndividual.PassportExpiryDate = businessPartner.BusinessPartnerIndividual.PassportExpiryDate;
                businessPartnerDbVersion.BusinessPartnerIndividual.PassportCountryId = businessPartner.BusinessPartnerIndividual.PassportCountryId;
                businessPartnerDbVersion.BusinessPartnerIndividual.LiscenseNumber = businessPartner.BusinessPartnerIndividual.LiscenseNumber;
                businessPartnerDbVersion.BusinessPartnerIndividual.LiscenseExpiryDate = businessPartner.BusinessPartnerIndividual.LiscenseExpiryDate;
                businessPartnerDbVersion.BusinessPartnerIndividual.TaxRegisterationCode = businessPartner.BusinessPartnerIndividual.TaxRegisterationCode;
                businessPartnerDbVersion.BusinessPartnerIndividual.TaxNumber = businessPartner.BusinessPartnerIndividual.TaxNumber;
                businessPartnerDbVersion.BusinessPartnerIndividual.IsCompanyExternal = businessPartner.BusinessPartnerIndividual.IsCompanyExternal;
                businessPartnerDbVersion.BusinessPartnerIndividual.BusinessPartnerCompnayId = businessPartner.BusinessPartnerIndividual.BusinessPartnerCompnayId;
                businessPartnerDbVersion.BusinessPartnerIndividual.CompanyName = businessPartner.BusinessPartnerIndividual.CompanyName;
                businessPartnerDbVersion.BusinessPartnerIndividual.CompanyPhone = businessPartner.BusinessPartnerIndividual.CompanyPhone;
                businessPartnerDbVersion.BusinessPartnerIndividual.CompanyAddress = businessPartner.BusinessPartnerIndividual.CompanyAddress;

                businessPartnerDbVersion.BusinessPartnerIndividual.RowVersion = businessPartnerDbVersion.BusinessPartnerIndividual.RowVersion + 1;
                businessPartnerDbVersion.BusinessPartnerIndividual.RecLastUpdatedDt = DateTime.Now;
                businessPartnerDbVersion.BusinessPartnerIndividual.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                #endregion

                //set child (buiness partner company properties)
                #region Business Partner Company
                businessPartnerDbVersion.BusinessPartnerCompany.BusinessPartnerId = businessPartner.BusinessPartnerId;
                businessPartnerDbVersion.BusinessPartnerCompany.BusinessPartnerCompanyCode =
                    businessPartner.BusinessPartnerCompany.BusinessPartnerCompanyCode;
                businessPartnerDbVersion.BusinessPartnerCompany.BusinessPartnerCompanyName =
                    businessPartner.BusinessPartnerCompany.BusinessPartnerCompanyName;
                businessPartnerDbVersion.BusinessPartnerCompany.BusinessSegmentId =
                    businessPartner.BusinessPartnerCompany.BusinessSegmentId;
                businessPartnerDbVersion.BusinessPartnerCompany.AccountNumber =
                    businessPartner.BusinessPartnerCompany.AccountNumber;
                businessPartnerDbVersion.BusinessPartnerCompany.EstablishedSince =
                    businessPartner.BusinessPartnerCompany.EstablishedSince;
                businessPartnerDbVersion.BusinessPartnerCompany.SwiftCode =
                    businessPartner.BusinessPartnerCompany.SwiftCode;

                businessPartnerDbVersion.BusinessPartnerCompany.RowVersion =
                    businessPartnerDbVersion.BusinessPartnerCompany.RowVersion + 1;
                businessPartnerDbVersion.BusinessPartnerCompany.RecLastUpdatedDt = DateTime.Now;
                businessPartnerDbVersion.BusinessPartnerCompany.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                #endregion

                //set child (business partner intypes)
                #region Business Partner InTypes
                //add new items
                foreach (BusinessPartnerInType itemInType in businessPartner.BusinessPartnerInTypes)
                {
                    if (businessPartnerDbVersion.BusinessPartnerInTypes.All(x => x.BusinessPartnerInTypeId != itemInType.BusinessPartnerInTypeId) || itemInType.BusinessPartnerInTypeId == 0)
                    {
                        // set user domain key
                        itemInType.UserDomainKey = businessPartnerRepository.UserDomainKey;
                        businessPartnerDbVersion.BusinessPartnerInTypes.Add(itemInType);
                    }
                }
                //find missing items
                List<BusinessPartnerInType> missingItems = new List<BusinessPartnerInType>();
                foreach (BusinessPartnerInType dbversionItemInType in businessPartnerDbVersion.BusinessPartnerInTypes)
                {
                    if (businessPartner.BusinessPartnerInTypes.All(x => x.BusinessPartnerInTypeId != dbversionItemInType.BusinessPartnerInTypeId))
                    {
                        missingItems.Add(dbversionItemInType);
                    }
                }
                //remove missing items
                foreach (BusinessPartnerInType missingBusinessPartnerInType in missingItems)
                {
                    BusinessPartnerInType dbVersionMissingItem = businessPartnerDbVersion.BusinessPartnerInTypes.First(x => x.BusinessPartnerInTypeId == missingBusinessPartnerInType.BusinessPartnerInTypeId);
                    if (dbVersionMissingItem.BusinessPartnerInTypeId > 0)
                    {
                        businessPartnerDbVersion.BusinessPartnerInTypes.Remove(dbVersionMissingItem);
                        businessPartnerInTypeRepository.Delete(dbVersionMissingItem);
                    }
                }

                #endregion

                //set child (business partner phones)
                #region Business Partner Phones
                //add new phone items
                foreach (Phone phone in businessPartner.BusinessPartnerPhoneNumbers)
                {
                    if (businessPartnerDbVersion.BusinessPartnerPhoneNumbers.All(x => x.PhoneId != phone.PhoneId) || phone.PhoneId == 0)
                    {
                        // set properties
                        phone.IsActive = true;
                        phone.IsDeleted = false;
                        phone.IsPrivate = false;
                        phone.IsReadOnly = false;
                        phone.RecCreatedDt = DateTime.Now;
                        phone.RecLastUpdatedDt = DateTime.Now;
                        phone.RecCreatedBy = businessPartnerRepository.LoggedInUserIdentity;
                        phone.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                        phone.RowVersion = 0;
                        phone.UserDomainKey = businessPartnerRepository.UserDomainKey;
                        businessPartnerDbVersion.BusinessPartnerPhoneNumbers.Add(phone);
                    }
                }
                //find missing phone items
                List<Phone> missingPhoneItems = new List<Phone>();
                foreach (Phone dbversionPhoneItem in businessPartnerDbVersion.BusinessPartnerPhoneNumbers)
                {
                    if (businessPartner.BusinessPartnerPhoneNumbers.All(x => x.PhoneId != dbversionPhoneItem.PhoneId))
                    {
                        missingPhoneItems.Add(dbversionPhoneItem);
                    }
                }
                //remove missing phone items
                foreach (Phone missingBusinessPartnerPhone in missingPhoneItems)
                {
                    Phone dbVersionMissingPhoneItem = businessPartnerDbVersion.BusinessPartnerPhoneNumbers.First(x => x.PhoneId == missingBusinessPartnerPhone.PhoneId);
                    if (dbVersionMissingPhoneItem.PhoneId > 0)
                    {
                        businessPartnerDbVersion.BusinessPartnerPhoneNumbers.Remove(dbVersionMissingPhoneItem);
                    }
                }
                #endregion

                //set child (business partner address list)
                #region Business Partner Address List
                //add new address items
                foreach (Address address in businessPartner.BusinessPartnerAddressList)
                {
                    if (businessPartnerDbVersion.BusinessPartnerAddressList.All(x => x.AddressId != address.AddressId) || address.AddressId == 0)
                    {
                        // set properties
                        address.IsActive = true;
                        address.IsDeleted = false;
                        address.IsPrivate = false;
                        address.IsReadOnly = false;
                        address.RecCreatedDt = DateTime.Now;
                        address.RecLastUpdatedDt = DateTime.Now;
                        address.RecCreatedBy = businessPartnerRepository.LoggedInUserIdentity;
                        address.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                        address.RowVersion = 0;
                        address.UserDomainKey = businessPartnerRepository.UserDomainKey;
                        businessPartnerDbVersion.BusinessPartnerAddressList.Add(address);
                    }
                }
                //find missing address items
                List<Address> missingAddressItems = new List<Address>();
                foreach (Address dbversionAddressItem in businessPartnerDbVersion.BusinessPartnerAddressList)
                {
                    if (businessPartner.BusinessPartnerAddressList.All(x => x.AddressId != dbversionAddressItem.AddressId))
                    {
                        missingAddressItems.Add(dbversionAddressItem);
                    }
                }
                //remove missing address items
                foreach (Address missingBusinessPartnerAddress in missingAddressItems)
                {
                    Address dbVersionMissingAddressItem = businessPartnerDbVersion.BusinessPartnerAddressList.First(x => x.AddressId == missingBusinessPartnerAddress.AddressId);
                    if (dbVersionMissingAddressItem.AddressId > 0)
                        businessPartnerDbVersion.BusinessPartnerAddressList.Remove(dbVersionMissingAddressItem);
                }
                #endregion

                //set child (business partner marketing channel list)
                #region Business Partner Marketing Channels
                //add new marketing channel items
                foreach (BusinessPartnerMarketingChannel channel in businessPartner.BusinessPartnerMarketingChannels)
                {
                    if (businessPartnerDbVersion.BusinessPartnerMarketingChannels
                        .All(x => x.BusinessPartnerMarketingChannelId != channel.BusinessPartnerMarketingChannelId) || channel.BusinessPartnerMarketingChannelId == 0)
                    {
                        // set properties
                        channel.RecCreatedDt = DateTime.Now;
                        channel.RecLastUpdatedDt = DateTime.Now;
                        channel.RecCreatedBy = businessPartnerRepository.LoggedInUserIdentity;
                        channel.RecLastUpdatedBy = businessPartnerRepository.LoggedInUserIdentity;
                        channel.RowVersion = 0;
                        channel.UserDomainKey = businessPartnerRepository.UserDomainKey;
                        businessPartnerDbVersion.BusinessPartnerMarketingChannels.Add(channel);
                    }
                }
                //find missing marketing channel items
                List<BusinessPartnerMarketingChannel> missingChannelItems = new List<BusinessPartnerMarketingChannel>();
                foreach (BusinessPartnerMarketingChannel dbversionChannelItem in businessPartnerDbVersion.BusinessPartnerMarketingChannels)
                {
                    if (businessPartner.BusinessPartnerMarketingChannels.
                        All(x => x.BusinessPartnerMarketingChannelId != dbversionChannelItem.BusinessPartnerMarketingChannelId))
                    {
                        missingChannelItems.Add(dbversionChannelItem);
                    }
                }
                //remove missing Business Marketing Channel items
                foreach (BusinessPartnerMarketingChannel missingBusinessPartnerChannel in missingChannelItems)
                {
                    BusinessPartnerMarketingChannel dbversionMissingChannelItem = businessPartnerDbVersion.BusinessPartnerMarketingChannels.First(x => x.BusinessPartnerMarketingChannelId == missingBusinessPartnerChannel.BusinessPartnerMarketingChannelId);
                    if (dbversionMissingChannelItem.BusinessPartnerMarketingChannelId > 0)
                        businessPartnerDbVersion.BusinessPartnerMarketingChannels.Remove(dbversionMissingChannelItem);
                }
                #endregion

                // save changes
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
