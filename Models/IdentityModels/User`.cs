// Copyright (c) KriaSoft, LLC.  All rights reserved.
// Licensed under the Apache License, Version 2.0.  See LICENSE.txt in the project root for license information.

using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cares.Models.IdentityModels
{
    public partial class User : IUser<string>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, string> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            ClaimsIdentity userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            userIdentity.AddClaim(new Claim("test","hell this all !"));
            // Add custom user claims here
            return userIdentity;
        }

    }
}