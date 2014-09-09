using System.Collections.Generic;
using System.Linq;
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
        public void DeleteWorkLocation(WorkLocation request)
        {
            WorkLocation dBworkLocation = workLocationRepository.Find(request.WorkLocationId);
            if (dBworkLocation != null)
            {
                workLocationRepository.Delete(dBworkLocation);
                workLocationRepository.SaveChanges();
            }
        }

        /// <summary>
        /// Save / Update Work Location
        /// </summary>
        public WorkLocation SaveWorkLocation(WorkLocation workLocationRequest)
        {
            WorkLocation dbWorkLocation = workLocationRepository.Find(workLocationRequest.WorkLocationId);
            // Edit Existing record
            #region EDIT
            if (dbWorkLocation != null)
            {
                IEnumerable<Phone> dBVersionPhones = phoneRepository.GetPhonesByWorkLocationId(dbWorkLocation.WorkLocationId);
                SetUpdateedProperties(dbWorkLocation, workLocationRequest, "update");

                // Checking if there is any Phone  in Worklocation request object
                if (workLocationRequest.Phones != null)
                {
                    // for every Phone in Worklocation request object
                    foreach (Phone phone in workLocationRequest.Phones)
                    {
                        // if there is any recored in Phone table in DB associated with worklocation
                        // ReSharper disable once PossibleMultipleEnumeration
                        if (dBVersionPhones.Count() != 0)
                        {
                            // for every Phone in dBVersionPhones object
                            foreach (Phone dbVersionPhone in dBVersionPhones)
                            {
                                // If Phone is newly created with id = 0 
                                if (phone.PhoneId == 0)
                                {
                                    phone.RecCreatedBy =
                                    phone.RecLastUpdatedBy = phoneRepository.LoggedInUserIdentity;
                                    phone.RecCreatedDt = phone.RecLastUpdatedDt = DateTime.Now;
                                    phone.UserDomainKey = 1;
                                //    phone.WorkLocationId = workLocationRequest.WorkLocationId;
                                    phone.IsActive = true;
                                    phone.IsDeleted = false;
                                    phone.IsPrivate = false;
                                    dbWorkLocation.Phones.Add(phone);
                                } // delete those Phone objects that are not in request obj
                                else if (phone.PhoneId != dbVersionPhone.PhoneId)
                                {
                                    Phone operationsWorkPlaces =
                                        phoneRepository.Find(dbVersionPhone.PhoneId);
                                    if (operationsWorkPlaces != null)
                                    {
                                        dbWorkLocation.Phones.Remove(operationsWorkPlaces);
                                        phoneRepository.Delete(operationsWorkPlaces);
                                    }
                                }
                            }
                        } // Add them for first time
                        else
                        {
                            phone.RecCreatedBy = phone.RecLastUpdatedBy = phoneRepository.LoggedInUserIdentity;
                            phone.RecCreatedDt = phone.RecLastUpdatedDt = DateTime.Now;
                            phone.UserDomainKey = 1;
                          //  phone.wo = workLocationRequest.WorkLocationId;
                            phone.IsActive = true;
                            phone.IsDeleted = false;
                            phone.IsPrivate = false;
                            if (dbWorkLocation.Phones == null)
                            {
                                dbWorkLocation.Phones = new List<Phone>();
                            }
                            dbWorkLocation.Phones.Add(phone);
                        }
                    }
                    //phoneRepository.SaveChanges();
                    workLocationRepository.Update(dbWorkLocation);
                    //workLocationRepository.SaveChanges();
                }   // request object does not contain any Phone , so delete all associated Phones entities 
                else
                {
                    foreach (Phone dbVersionOPhone in dBVersionPhones)
                    {
                        Phone phone = phoneRepository.Find(dbVersionOPhone.PhoneId);
                        if (phone != null)
                        {
                            dbWorkLocation.Phones.Remove(phone);
                            phoneRepository.Delete(phone);
                        }
                    }
                }
            }
            #endregion
            // Add new record
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
            //    workLocationRepository.SaveChanges();
            }
            #endregion

            workLocationRepository.SaveChanges();
            phoneRepository.SaveChanges();

            // Get detailed object of worklocation
            return workLocationRepository.GetWorkLocationWithDetails(workLocationRequest.WorkLocationId);
        }
        #endregion
    }
}
