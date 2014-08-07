using Models.DomainModels;
using System.Collections.Generic;

namespace Interfaces.Repository
{
    /// <summary>
    /// Region Repository Interface
    /// </summary>
    public interface IRegionRepository : IBaseRepository<Region, long>
    {
        IEnumerable<Region> GetRegions(int id);
    }
}
