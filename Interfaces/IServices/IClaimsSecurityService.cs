﻿//using Microsoft.IdentityModel.Claims;
//using Microsoft.IdentityModel.Web;
//using MPC.Models.Common;

using System.Security.Claims;
using System.Threading.Tasks;
using Cares.Models.Common;
using Cares.Models.IdentityModels;

namespace Cares.Interfaces.IServices
{

    /// <summary>
    /// Service that adds security claims to the 
    /// </summary>
    public interface IClaimsSecurityService
    {
        /// <summary>
        ///// Handles the <see cref="WSFederationAuthenticationModule.SecurityTokenValidated"/> event
        /// </summary>
        //void SecurityTokenValidated(object sender, SecurityTokenValidatedEventArgs e, string ipAddress);

        /// <summary>
        /// Lookup identity using the claims identity
        /// </summary>
      //  ClaimsIdentity LookupIdentity(ClaimsIdentity claimsIdentity);

       

        /// <summary>
        /// Lookup name id and provider name
        /// </summary>
     //   void LookupIdentityClaimValues(ClaimsIdentity claimsIdentity, out string providerName, out string nameIdentifier);
    }
}