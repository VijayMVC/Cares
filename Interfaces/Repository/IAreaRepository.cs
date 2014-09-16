using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Area Repository Interface
    /// </summary>
    public interface IAreaRepository : IBaseRepository<Area, int>
    {
        /// <summary>
        /// To check the association of area and city
        /// </summary>
        bool IsCityAssociatedWithArea(long citId);

        /// <summary>
        /// Search Area
        /// </summary>
        IEnumerable<Area> SearchArea(AreaSearchRequest request, out int rowCount);

        /// <summary>
        /// To validte the code duplication check
        /// </summary>
        bool DoesAreaCodeExist(Area area);


        /// <summary> 
        /// Load detail instence of area
        /// </summary>
        Area LoadAreaWithDetail(long areaId);
    }
}
