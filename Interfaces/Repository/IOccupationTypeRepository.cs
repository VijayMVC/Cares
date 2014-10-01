using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Occupation Type Repository Interface
    /// </summary>
    public interface IOccupationTypeRepository : IBaseRepository<OccupationType, long>
    {
        /// <summary>
        /// Search Occupation Type
        /// </summary>
        IEnumerable<OccupationType> SearchOccupationType(OccupationTypeSearchRequest request, out int rowCount);

        /// <summary>
        /// Self Occupation Type code check 
        /// </summary>
        bool OccupationTypeCodeDuplicationCheck(OccupationType occupationType);
    }
}
