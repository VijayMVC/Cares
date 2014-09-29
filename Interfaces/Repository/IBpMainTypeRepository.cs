using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using System.Collections.Generic;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Business Partner Main Type Repository Interface
    /// </summary>
    public interface IBpMainTypeRepository : IBaseRepository<BusinessPartnerMainType, int>
    {

        /// <summary>
        /// Search Business Partner Main Type
        /// </summary>
        IEnumerable<BusinessPartnerMainType> SearchBpMainType(BpMainTypeSearchRequest request, out int rowCount);

        /// <summary>
        ///Business Partner Main Type Code duplication check 
        /// </summary>
        bool DoesBpMainTypeCodeExists(BusinessPartnerMainType businessPartnerMainType);

        
    }
    }

