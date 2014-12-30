
using System.Security.Claims;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Service that adds security claims to the identity
    /// </summary>
    public interface IClaimsSecurityService
    {
        /// <summary>
        /// Adds user claims to Identity
        /// </summary>
        void AddClaimsToIdentity(long domainKey, string defaultRole, string userName, ClaimsIdentity identity);

    }
}
