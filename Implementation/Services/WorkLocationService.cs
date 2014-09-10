using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Cares.ExceptionHandling;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Work Location Service
    /// </summary>
    public class WorkLocationService : IWorkLocationService
    {
        #region Private

        private readonly IWorkLocationRepository workLocationRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IRegionRepository regionRepository;
        private readonly ISubRegionRepository subRegionRepository;
        private readonly ICityRepository cityRepository;
        private readonly IAreaRepository areaRepository;
        private readonly IPhoneTypeRepository phoneTypeRepository;
        private readonly IPhoneRepository phoneRepository;

        /// <summary>
        /// Updates the db instance with user data for add/update operation
        /// </summary>
        private void SetUpdateedProperties(WorkLocation dbvWorkLocation, WorkLocation upDatedWorkLocation , String operation)
        {
            if (operation.Equals("update"))
            {
                dbvWorkLocation.RecLastUpdatedBy = workLocationRepository.LoggedInUserIdentity;
                dbvWorkLocation.RecLastUpdatedDt = DateTime.Now;
                dbvWorkLocation.WorkLocationCode = upDatedWorkLocation.WorkLocationCode;
                dbvWorkLocation.WorkLocationName = upDatedWorkLocation.WorkLocationName;
                dbvWorkLocation.WorkLocationDescription = upDatedWorkLocation.WorkLocationDescription;

                dbvWorkLocation.Address.ContactPerson = upDatedWorkLocation.Address.ContactPerson;
                dbvWorkLocation.Address.StreetAddress = upDatedWorkLocation.Address.StreetAddress;

                dbvWorkLocation.Address.EmailAddress = upDatedWorkLocation.Address.EmailAddress;
                dbvWorkLocation.Address.WebPage = upDatedWorkLocation.Address.WebPage;
                dbvWorkLocation.Address.ZipCode = upDatedWorkLocation.Address.ZipCode;

                dbvWorkLocation.Address.POBox = upDatedWorkLocation.Address.POBox;
                dbvWorkLocation.Address.CountryId = upDatedWorkLocation.Address.CountryId;
                dbvWorkLocation.Address.RegionId = upDatedWorkLocation.Address.RegionId;

                dbvWorkLocation.Address.SubRegionId = upDatedWorkLocation.Address.SubRegionId;
                dbvWorkLocation.Address.CityId = upDatedWorkLocation.Address.CityId;
                dbvWorkLocation.Address.AreaId = upDatedWorkLocation.Address.AreaId;
            }
            else
            {
                upDatedWorkLocation.RecCreatedBy = upDatedWorkLocation.RecLastUpdatedBy = upDatedWorkLocation.Address.RecCreatedBy= 
                upDatedWorkLocation.Address.RecLastUpdatedBy= workLocationRepository.LoggedInUserIdentity;

                upDatedWorkLocation.RecCreatedDt=upDatedWorkLocation.Address.RecCreatedDt= DateTime.Now;
                upDatedWorkLocation.RecLastUpdatedDt = upDatedWorkLocation.Address.RecLastUpdatedDt= DateTime.Now;
                upDatedWorkLocation.UserDomainKey = upDatedWorkLocation.Address.UserDomainKey=1;
                upDatedWorkLocation.Address.AddressTypeId = 1;
            }
        }

        /// <summary>
        /// Deletion of Phone with iD
        /// </summary>
        /// <param name="phoneId"></param>
        private void DeletePhone(long phoneId)
        {
            Phone phone = phoneRepository.Find(phoneId);
            if (phone != null)
            {
                phoneRepository.Delete(phone);
            }
        }

        #endregion
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public WorkLocationService(IWorkLocationRepository workLocationRepository, ICompanyRepository companyRepository,
            ICountryRepository countryRepository,
            IRegionRepository regionRepository, ISubRegionRepository subRegionRepository, ICityRepository cityRepository,
            IAreaRepository areaRepository, IPhoneTypeRepository phoneTypeRepository, IPhoneRepository phoneRepository)
        {
            this.workLocationRepository = workLocationRepository;
            this.companyRepository = companyRepository;
            this.countryRepository = countryRepository;
            this.regionRepository = regionRepository;
            this.subRegionRepository = subRegionRepository;
            this.cityRepository = cityRepository;
            this.areaRepository = areaRepository;
            this.phoneTypeRepository = phoneTypeRepository;
            this.phoneRepository = phoneRepository;
        }

        #endregion
        #region Public

        /// <summary>
        /// Load Work Location Base Data
        /// </summary>
        public WorkLocationBaseDataResponse LoadWorkLocationBaseData()
        {
            return new WorkLocationBaseDataResponse
            {
                Companies = companyRepository.GetAll(),
                Countries = countryRepository.GetAll(),
                Regions = regionRepository.GetAll(),
                SubRegions = subRegionRepository.GetAll(),
                Cities = cityRepository.GetAll(),
                Areas = areaRepository.GetAll(),
                PhoneTypes = phoneTypeRepository.GetAll()
            };
        }

        /// <summary>
        /// Search Work Locations
        /// </summary>
        public WorkLocationSerachRequestResponse SearchWorkLocation(WorkLocationSearchRequest request)
        {
            int rowCount;
            return new WorkLocationSerachRequestResponse
            {
                WorkLocations = workLocationRepository.SearchWorkLocation(request, out rowCount),
                TotalCount = rowCount

            };
        }

        /// <summary>
        /// Delete Work Location
        /// </summary>
        public void DeleteWorkLocation(long workLocationId)
        {
            WorkLocation dBworkLocation = workLocationRepository.Find(workLocationId);
            if (dBworkLocation != null)
            {
                workLocationRepository.Delete(dBworkLocation);
                workLocationRepository.SaveChanges();
            }
            else
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture,
                              "WorkLocation with Id {0} not found!", workLocationId));
        }

        /// <summary>
        /// Save / Update Work Location
        /// </summary>
        public WorkLocation SaveWorkLocation(WorkLocation workLocationRequest)
        {
            // Check the availability of workLocation code
            if (workLocationRepository.DoesWorkLocationCodeExists(workLocationRequest))
                throw new CaresException(Resources.Organization.WorkLocation.WorkLocationWithSameCodeExistsError); 

            WorkLocation dbWorkLocation = workLocationRepository.Find(workLocationRequest.WorkLocationId);
            bool isFind = false;

            #region Edit
            if (dbWorkLocation != null)
            {
                IEnumerable<Phone> dBVersionPhones = phoneRepository.GetPhonesByWorkLocationId(dbWorkLocation.WorkLocationId);
                SetUpdateedProperties(dbWorkLocation, workLocationRequest, "update");
                #region Phones already exists in DB
                // ReSharper disable once PossibleMultipleEnumeration
                if (dBVersionPhones.Any())
                {
                    // check for every phone in DB
                    foreach (Phone dBPhone in dBVersionPhones)
                    {
                        //If DbPhone matches to any of request phone than dont delete it else delete 
                        if (workLocationRequest.Phones!=null)
                        {
                            if (workLocationRequest.Phones.Any(reqPhone => reqPhone.PhoneId == dBPhone.PhoneId))
                                isFind = true;
                        }
                        else
                            DeletePhone(dBPhone.PhoneId);
                        if (!isFind)
                            DeletePhone(dBPhone.PhoneId);
                        isFind = false;
                    }
                }
                #endregion
                #region Adding New Phones 
                else
                {
                    foreach (var newPhone in workLocationRequest.Phones)
                    {
                        newPhone.RecCreatedBy = newPhone.RecLastUpdatedBy = phoneRepository.LoggedInUserIdentity;
                        newPhone.RecCreatedDt = newPhone.RecLastUpdatedDt = DateTime.Now;
                        newPhone.UserDomainKey = 1;
                        newPhone.IsActive = true;
                        newPhone.IsDeleted = false;
                        newPhone.IsPrivate = false;
                        dbWorkLocation.Phones.Add(newPhone);
                    }
                }
                #endregion
                #region Adding Phones when there are more phones in request thatn in DB
                if (workLocationRequest.Phones != null && workLocationRequest.Phones.Count > dBVersionPhones.Count())
                foreach (var newPhonee in workLocationRequest.Phones)
                {
                    if (newPhonee.PhoneId == 0)
                    {
                        newPhonee.RecCreatedBy = newPhonee.RecLastUpdatedBy = phoneRepository.LoggedInUserIdentity;
                        newPhonee.RecCreatedDt = newPhonee.RecLastUpdatedDt = DateTime.Now;
                        newPhonee.UserDomainKey = 1;
                        newPhonee.IsActive = true;
                        newPhonee.IsDeleted = false;
                        newPhonee.IsPrivate = false;
                        dbWorkLocation.Phones.Add(newPhonee);
                    }
                }
                #endregion
                workLocationRepository.Update(dbWorkLocation);
            }
            #endregion
            #region ADD
            else
            {
                SetUpdateedProperties(null, workLocationRequest, "insert");
                if (workLocationRequest.Phones != null)
                {
                    foreach (var phone in (workLocationRequest.Phones))
                    {
                        phone.RecCreatedBy = phone.RecLastUpdatedBy = phoneRepository.LoggedInUserIdentity;
                        phone.RecCreatedDt = phone.RecLastUpdatedDt = DateTime.Now;
                        phone.UserDomainKey = 1;
                        phone.IsActive = true;
                        phone.IsDeleted = false;
                        phone.IsPrivate = false;
                    }
                }
                workLocationRepository.Add(workLocationRequest);
            }
            #endregion

            phoneRepository.SaveChanges();
            workLocationRepository.SaveChanges();
            // Get detailed object of worklocation
            return workLocationRepository.GetWorkLocationWithDetails(workLocationRequest.WorkLocationId);
        }
        #endregion
    }
}
