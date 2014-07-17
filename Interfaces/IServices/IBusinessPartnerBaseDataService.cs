using System.Linq;
using Models.DomainModels;
using Models.ResponseModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// Business Partner Base Service Interface
    /// </summary>
    public interface IBusinessPartnerBaseDataService
    {
        /// <summary>
        /// Load All base data
        /// </summary>
        /// <returns></returns>
        BusinessPartnerBaseDataResponse LoadAll();
    }
}
