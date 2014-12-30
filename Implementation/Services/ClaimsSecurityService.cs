using System;
using Cares.Commons;
using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.CommonTypes;
using Cares.Models.DomainModels;
using System.Globalization;
using System.Security.Claims;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Service that manages security claims
    /// </summary>
    public class ClaimsSecurityService :  IClaimsSecurityService
    {
        #region Private

        private IDomainLicenseDetailsRepository domainLicenseDetailsRepository;
       
        #endregion
        #region Constructor

        public ClaimsSecurityService(IDomainLicenseDetailsRepository domainLicenseDetailsRepository)
        {
            this.domainLicenseDetailsRepository = domainLicenseDetailsRepository;
        }

        #endregion
        #region Public


        /// <summary>
        /// Add Domain License Detail Claims
        /// </summary>
        private void AddDomainLicenseDetailClaims(long domainKey, ClaimsIdentity identity)
        {
               DomainLicenseDetail domainLicenseDetail =
                   domainLicenseDetailsRepository.GetDomainLicenseDetailByDomainKey(domainKey);
            if (domainLicenseDetail != null)
            {
                var claim = new Claim(CaresUserClaims.DomainLicenseDetail,
                    ClaimHelper.Serialize(
                        new DomainLicenseDetailClaim
                        {
                            UserDomainKey = domainLicenseDetail.UserDomainKey,
                            Branches = domainLicenseDetail.Branches,
                            FleetPools = domainLicenseDetail.FleetPools,
                            Employee = domainLicenseDetail.Employee,
                            RaPerMonth = domainLicenseDetail.RaPerMonth,
                            Vehicles = domainLicenseDetail.Vehicles
                        }),
                    typeof (DomainLicenseDetailClaim).AssemblyQualifiedName);
                    ClaimHelper.AddClaim(claim, identity);
            }
            else
            {
                throw new InvalidOperationException("No Domain License Detail data found!");
            }
        }
        
        /// <summary>
        /// Add  general claims 
        /// </summary>
        public void AddClaimsToIdentity(long domainKey, string defaultRoleName, string userName, ClaimsIdentity identity)
        {
            ClaimHelper.AddClaim(new Claim(CaresUserClaims.UserDomainKey, domainKey.
                ToString(CultureInfo.InvariantCulture)), identity);                              //domainkey claim
            ClaimHelper.AddClaim(new Claim(CaresUserClaims.Role, defaultRoleName), identity);   // role claim
            ClaimHelper.AddClaim(new Claim(CaresUserClaims.Name, userName), identity);         // user name claim
            AddDomainLicenseDetailClaims(domainKey, identity);                                // domain license detail claim
        }
        #endregion
    }
}
