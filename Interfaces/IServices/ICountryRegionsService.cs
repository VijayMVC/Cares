using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.IServices
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
