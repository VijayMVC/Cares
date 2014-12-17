using Cares.Interfaces.IServices;
using Cares.Interfaces.Repository;
using Cares.Models.DomainModels;

namespace Cares.Implementation.Services
{
    public class DomainLicenseDetailsService : IDomainLicenseDetailsService
    {
        #region Private

        private IDomainLicenseDetailsRepository domainLicenseDetailsRepository;

        #endregion
        #region Constructor
        public DomainLicenseDetailsService(IDomainLicenseDetailsRepository domainLicenseDetailsRepository)
        {
            this.domainLicenseDetailsRepository = domainLicenseDetailsRepository;
        }
        #endregion

        /// <summary>
        /// Get Domain License Details by Domain key
        /// </summary>
       public DomainLicenseDetail GetDomainLicenseDetailsByDomainKey(double domainkey)
        {
            return domainLicenseDetailsRepository.GetDomainLicenseDetailByDomainKey(domainkey);
        }
    }
}
