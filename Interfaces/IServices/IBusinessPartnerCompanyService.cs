
using System.Collections.Generic;
using Models.DomainModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// Business Partner Company Service Interface
    /// </summary>
    public interface IBusinessPartnerCompanyService
    {
        /// <summary>
        /// Get All Business Partner Companies
        /// </summary>
        /// <returns></returns>
        IEnumerable<BusinessPartnerCompany> LoadAll();
    }
}
