﻿using Cares.Models.IdentityModels.ViewModels;

namespace Cares.Interfaces.IServices
{
    public interface IRegisterUserService
    {
        /// <summary>
        /// User Model
        /// </summary>
        void AddLicenseDetail(RegisterViewModel userModel, double domainkey);

        /// <summary>
        /// Gives the maximum domain key from the records
        /// </summary>
        double GetMaxUserDomainKey();
    }
}