using System.Collections.Generic;
using Cares.Models.DomainModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Region Repository Interface
    /// </summary>
    public interface IRegionRepository : IBaseRepository<Region, long>
    {
        IEnumerable<Region> GetRegions(int id);
    }
}
