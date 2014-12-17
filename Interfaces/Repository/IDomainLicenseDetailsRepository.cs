using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    public interface IDomainLicenseDetailsRepository : IBaseRepository<DomainLicenseDetail, long>
    {
        /// <summary>
        /// Get Domain License Detail By DomainKey
        /// </summary>
        DomainLicenseDetail GetDomainLicenseDetailByDomainKey(double domainKey);
    }
}
