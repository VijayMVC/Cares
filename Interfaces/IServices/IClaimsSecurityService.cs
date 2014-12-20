
using System.Security.Claims;
using Cares.Models.IdentityModels;

namespace Cares.Interfaces.IServices
{

    /// <summary>
    /// Service that adds security claims to the 
    /// </summary>
    public interface IClaimsSecurityService
    {
        /// <summary>
        /// Adds user claims to Identity
        /// </summary>
        void AddClaimsToIdentity(User user , ClaimsIdentity identity);

    }
}
