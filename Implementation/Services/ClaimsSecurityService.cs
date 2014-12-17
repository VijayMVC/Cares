using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.Common;
using Cares.Models.CommonTypes;
using Cares.Models.DomainModels;
using Cares.Models.IdentityModels;
using System;
using System.Security.Claims;
using System.Threading;
using Castle.MicroKernel.Registration;
using Microsoft.Practices.Unity;

namespace Cares.Implementation.Services
{
    /// <summary>
    /// Service that manages security claims
    /// </summary>
    public class ClaimsSecurityService : MarshalByRefObject, IClaimsSecurityService
    {
        #region Private

        public IDomainLicenseDetailsRepository DomainLicenseDetailsRepository;
       
        #endregion
        #region Constructor

        public ClaimsSecurityService()
        {
            
        }

        #endregion
        #region Public


        /// <summary>
        /// Add Organisation Claims
        /// </summary>
        private static void AddOrganisationClaims(User user, ClaimsIdentity claimsIdentity)
        {
            //   DomainLicenseDetail domainLicenseDetail =
            //       DomainLicenseDetailsRepository.GetDomainLicenseDetailByDomainKey(user.UserDomainKey);
            Claim claim = new Claim(CaresUserClaims.DomainLicenseDetail,
                                        ClaimHelper.Serialize(
                                            new DomainLicenseDetailClaim
                                            {
                                               UserDomainKey = -2,
                                               Branches = 5,
                                               FleetPools = 7,
                                               Employee = 12,
                                               RaPerMonth = 9
                                            }),
                                        typeof(DomainLicenseDetailClaim).AssemblyQualifiedName);
            claimsIdentity.AddClaim(claim);
        }
        


        /// <summary>
        /// Add claims to the identity
        /// </summary>
        public void AddClaimsToIdentity(User user, ClaimsIdentity identity)
        {
        
            if (user.UserName != null)
            {
                identity.AddClaim(new Claim(CaresUserClaims.Country, "Kongo"));
                AddOrganisationClaims(user, identity);

                Thread.CurrentPrincipal = new ClaimsPrincipal(identity);
            }
        }

        #endregion


    }
}
