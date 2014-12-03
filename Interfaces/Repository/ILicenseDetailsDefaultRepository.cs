using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    public interface ILicenseDetailsDefaultRepository : IBaseRepository<LicenseDetailsDefault, long>
    {
        /// <summary>
        /// Get License Details Default by Id
        /// </summary>
        LicenseDetailsDefault GetLicenseDetailsDefaultByTypeId(long licenseDetailsDefaultId);
    }
}
