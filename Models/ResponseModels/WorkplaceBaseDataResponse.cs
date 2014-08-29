using Cares.Models.DomainModels;
using System.Collections.Generic;

namespace Cares.Models.ResponseModels
{
    /// <summary>
    /// Workplace Base Data Response class
    /// </summary>
    public class WorkplaceBaseDataResponse
    {
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<WorkPlaceType> WorkPlaceTypes { get; set; }
        public IEnumerable<WorkLocation> WorkLocations { get; set; }
    }
}
