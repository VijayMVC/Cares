using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly IAddressRepository addressRepository;
        private readonly IAddressTypeRepository addressTypeRepository;

        /// <summary>
        /// Updates the db instance with user data for add/update operation
        /// </summary>
        private void SetUpdatedWorkLocationProperties(WorkLocation dbvWorkLocation, WorkLocation upDatedWorkLocation)
        {
            dbvWorkLocation.Address.RecLastUpdatedBy = dbvWorkLocation.RecLastUpdatedBy = workLocationRepository.LoggedInUserIdentity;
            dbvWorkLocation.Address.RecLastUpdatedDt = dbvWorkLocation.RecLastUpdatedDt = DateTime.Now;
            dbvWorkLocation.Address.RowVersion = dbvWorkLocation.Address.RowVersion + 1;
            dbvWorkLocation.RowVersion = dbvWorkLocation.RowVersion + 1;

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
        /// <summary>
        /// Update Worklocation
        /// </summary>
        private void UpdateWorkLocation(WorkLocation workLocationRequest, WorkLocation dbWorkLocation)
        {
            IEnumerable<Phone> dBVersionPhones = phoneRepository.GetPhonesByWorkLocationId(dbWorkLocation.WorkLocationId);
            SetUpdatedWorkLocationProperties(dbWorkLocation, workLocationRequest);
            // ReSharper disable PossibleMultipleEnumeration
            if (dBVersionPhones.Any())
            {
                foreach (Phone dBVersionPhone in dBVersionPhones.ToList())
                // ReSharper restore PossibleMultipleEnumeration
                {
                    if (workLocationRequest.Phones == null || workLocationRequest.Phones.FirstOrDefault(ph => ph.PhoneId == dBVersionPhone.PhoneId) == null)
                    {
                        DeletePhone(dBVersionPhone.PhoneId);
                    }
                }
            }
            if (workLocationRequest.Phones == null)
                workLocationRequest.Phones = new Collection<Phone>();

            IList<Phone> newlyAddedPhoneList = workLocationRequest.Phones.Where(ph => ph.PhoneId == 0).ToList();
            foreach (Phone newPhone in newlyAddedPhoneList)
            {
                newPhone.RecCreatedBy = newPhone.RecLastUpdatedBy = phoneRepository.LoggedInUserIdentity;
                newPhone.RecCreatedDt = newPhone.RecLastUpdatedDt = DateTime.Now;
                newPhone.UserDomainKey = phoneRepository.UserDomainKey;
                newPhone.RowVersion = 0;
                newPhone.IsActive = true;
                newPhone.IsDeleted = false;
                newPhone.IsPrivate = false;
                dbWorkLocation.Phones.Add(newPhone);
            }
            workLocationRepository.Update(dbWorkLocation);
        }
        /// <summary>
        /// Add Worklocation
        /// </summary>
        private WorkLocation AddWorkLocation(WorkLocation workLocationRequest)
        {
            WorkLocation dbWorkLocation = workLocationRepository.Create();
            SetInsertedWorkLocationProperties(dbWorkLocation, workLocationRequest);
            if (workLocationRequest.Phones != null)
            {
                dbWorkLocation.Phones = new List<Phone>();
                foreach (Phone phone in workLocationRequest.Phones)
                {
                    phone.RecCreatedBy = phone.RecLastUpdatedBy = phoneRepository.LoggedInUserIdentity;
                    phone.RecCreatedDt = phone.RecLastUpdatedDt = DateTime.Now;
                    phone.UserDomainKey = workLocationRepository.UserDomainKey;
                    phone.RowVersion = 0;
                    phone.IsActive = true;
                    phone.IsDeleted = false;
                    phone.IsPrivate = false;
                    phone.IsReadOnly = false;
                    dbWorkLocation.Phones.Add(phone);
                }
            }
            workLocationRepository.Add(dbWorkLocation);
            return dbWorkLocation;
        }
        /// <summary>
        /// Set Inserted Worklocation properties
        /// </summary>
        private void SetInsertedWorkLocationProperties(WorkLocation dbWorkLocation, WorkLocation workLocationRequest)
        {

            dbWorkLocation.Address = new Address
            {
                ContactPerson = workLocationRequest.Address.ContactPerson,
                StreetAddress = workLocationRequest.Address.StreetAddress,
                EmailAddress = workLocationRequest.Address.EmailAddress,
                WebPage = workLocationRequest.Address.WebPage,
                ZipCode = workLocationRequest.Address.ZipCode,
                POBox = workLocationRequest.Address.POBox,
                AddressTypeId = addressTypeRepository.GetAddressTypeIdByAddressTypeKey(1),
                CountryId = workLocationRequest.Address.CountryId,
                RegionId = workLocationRequest.Address.RegionId,
                SubRegionId = workLocationRequest.Address.SubRegionId,
                CityId = workLocationRequest.Address.CityId,
                AreaId = workLocationRequest.Address.AreaId,
                RecCreatedBy = workLocationRepository.LoggedInUserIdentity,
                RecCreatedDt = DateTime.Now,
                RecLastUpdatedDt = DateTime.Now,
                RecLastUpdatedBy = workLocationRepository.LoggedInUserIdentity,
                RowVersion = 0
            };
            dbWorkLocation.RecCreatedBy = dbWorkLocation.RecLastUpdatedBy = workLocationRepository.LoggedInUserIdentity;
            dbWorkLocation.RecLastUpdatedDt = dbWorkLocation.RecCreatedDt = DateTime.Now;
            dbWorkLocation.RowVersion = 0;
            dbWorkLocation.UserDomainKey = workLocationRepository.UserDomainKey;
            dbWorkLocation.CompanyId = workLocationRequest.CompanyId;
            dbWorkLocation.WorkLocationCode = workLocationRequest.WorkLocationCode;
            dbWorkLocation.WorkLocationName = workLocationRequest.WorkLocationName;
            dbWorkLocation.WorkLocationDescription = workLocationRequest.WorkLocationDescription;

        }
        /// <summary>
        /// Deletion of Phone with iD
        /// </summary>
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
            IAreaRepository areaRepository, IPhoneTypeRepository phoneTypeRepository, IPhoneRepository phoneRepository, IAddressRepository addressRepository,
            IAddressTypeRepository addressTypeRepository)
        {
            this.workLocationRepository = workLocationRepository;
            this.addressTypeRepository = addressTypeRepository;
            this.companyRepository = companyRepository;
            this.countryRepository = countryRepository;
            this.regionRepository = regionRepository;
            this.subRegionRepository = subRegionRepository;
            this.cityRepository = cityRepository;
            this.areaRepository = areaRepository;
            this.phoneTypeRepository = phoneTypeRepository;
            this.phoneRepository = phoneRepository;
            this.addressRepository = addressRepository;
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
            if (dBworkLocation != null && dBworkLocation.Workplaces.Any())
            {
                throw new CaresException(Resources.Organization.WorkLocation.WorkLocationDeleteFailedWorkplaceExists);
            }
            if (dBworkLocation != null)
            {
                addressRepository.Delete(dBworkLocation.Address);
                workLocationRepository.Delete(dBworkLocation);
                workLocationRepository.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.Organization.WorkLocation.WorklocationNotFoundInDatabase));
            }
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

            if (dbWorkLocation != null)
            {
                UpdateWorkLocation(workLocationRequest, dbWorkLocation);
            }
            else
            {
                dbWorkLocation = AddWorkLocation(workLocationRequest);
            }

            workLocationRepository.SaveChanges();
            // Get detailed object of worklocation
            return workLocationRepository.GetWorkLocationWithDetails(dbWorkLocation.WorkLocationId);
        }
        #endregion
    }
}
