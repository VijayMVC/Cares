﻿using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;
using Cares.Models.IdentityModels;
using Cares.Models.IdentityModels.ViewModels;
using System;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Register User Service 
    /// </summary>
    public class RegisterUserService : IRegisterUserService
    {
        #region Private

        private readonly ILicenseDetailsDefaultRepository licenseDetailsDefaultRepository;
        private readonly IDomainLicenseDetailsRepository domainLicenseDetailsRepository;
        private readonly IUserRepository userRepository;
        private readonly IUserDetailsRepository userDetailsRepository;
        /// <summary>
        /// Constructor
        /// </summary>
        public RegisterUserService(ILicenseDetailsDefaultRepository licenseDetailsDefaultRepository, IDomainLicenseDetailsRepository domainLicenseDetailsRepository,
            IUserRepository userRepository, IUserDetailsRepository userDetailsRepository)
        {
            this.licenseDetailsDefaultRepository = licenseDetailsDefaultRepository;
            this.domainLicenseDetailsRepository = domainLicenseDetailsRepository;
            this.userRepository = userRepository;
            this.userDetailsRepository = userDetailsRepository;
        }
        #endregion
        #region Public

        /// <summary>
        /// Add License Details and return user domain key
        /// </summary>
        public void AddLicenseDetail(RegisterViewModel userModel, double domainkey)
        {
            LicenseDetailsDefault licenseDetailsDefaultById = licenseDetailsDefaultRepository.GetLicenseDetailsDefaultByTypeId(Convert.ToInt32(userModel.AccountType));
            #region Adding Domain License Details
            DomainLicenseDetail licenseDetailObject = domainLicenseDetailsRepository.Create();
            licenseDetailObject.UserDomainKey = Convert.ToInt64(domainkey + 1);
            licenseDetailObject.RaPerMonth = licenseDetailsDefaultById.RaPerMonth;
            licenseDetailObject.Employee = licenseDetailsDefaultById.Employee;
            licenseDetailObject.Branches = licenseDetailsDefaultById.Branches;
            licenseDetailObject.FleetPools = licenseDetailsDefaultById.FleetPools;
            licenseDetailObject.Vehicles = licenseDetailsDefaultById.Vehicles;
            licenseDetailObject.IsActive = true;
            licenseDetailObject.IsDeleted = false;
            licenseDetailObject.IsPrivate = false;
            licenseDetailObject.IsReadOnly = false;
            licenseDetailObject.RecCreatedBy = "";
            licenseDetailObject.RecCreatedDt = DateTime.Now;
            licenseDetailObject.RecLastUpdatedBy = "";
            licenseDetailObject.RecLastUpdatedDt = DateTime.Now;
            domainLicenseDetailsRepository.Add(licenseDetailObject);
            domainLicenseDetailsRepository.SaveChanges();
            #endregion
        }

        /// <summary>
        /// Gives the maximum domain key from the records
        /// </summary>
        public double GetMaxUserDomainKey()
        {
            return userRepository.GetMaxUserDomainKey();
        }

        /// <summary>
        /// Saves user details provided while signup
        /// </summary>
        public void SaveUserDetails(User addedUser, RegisterViewModel model)
        {
            UserDetail user = userDetailsRepository.Create();
            user.AccountType = model.AccountType;
            user.Address = model.CompanyAddress;
            user.CompanyName = model.CompanyName;
            user.CountryName = model.CountryName;
            user.UserId = addedUser.Id;
            userDetailsRepository.Add(user);
            userDetailsRepository.SaveChanges();
        }
        /// <summary>
        /// Executes store procedure for copying default data for newly registered user
        /// </summary>
        public void SetupUserDefaultData(string userId)
        {
            UserDetail userDetails = userDetailsRepository.FindByUserId(userId);
            if (userDetails != null)
            {
                User user = userRepository.FindUserById(userId);
                if (user == null)
                {
                    throw new Exception("User not found!");
                }
                userDetailsRepository.CopyUserDefaultData(userId, user.UserDomainKey);
            }
        }
        #endregion
    }
}