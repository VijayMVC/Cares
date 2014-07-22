
using System.Collections.Generic;
using Models.DomainModels;

namespace Interfaces.IServices
{
    /// <summary>
    /// Occupation Type Service Interface
    /// </summary>
    public interface IOccupationTypeService
    {
        /// <summary>
        /// Get All Occupation Types
        /// </summary>
        /// <returns></returns>
        IEnumerable<OccupationType> LoadAll();
    }
}
