using Models.DomainModels;
using Models.RequestModels;
using Models.ResponseModels;
using System.Collections.Generic;

namespace Interfaces.IServices
{
    /// <summary>
    /// FleetPool Interface
    /// </summary>
    public interface ICountryRegionsService
    {
        /// <summary>
        /// Load All FleetPools
        /// </summary>
        IEnumerable<Region> GetCoutryRegion(int searchRequest);

       
    }
}
