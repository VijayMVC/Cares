
using Cares.Models.DomainModels;

namespace Cares.Interfaces.IServices
{
    public interface IDomainLicenseDetailsService
    {
        /// <summary>
        /// Get Domain License Details by Domain key
        /// </summary>
        DomainLicenseDetail GetDomainLicenseDetailsByDomainKey(double domainkey);

    }
}
