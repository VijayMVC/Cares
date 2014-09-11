using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;

namespace Cares.Interfaces.Repository
{
    /// <summary>
    /// Workplace Type Repository Interface
    /// </summary>
    public interface IWorkplaceTypeRepository : IBaseRepository<WorkPlaceType, long>
    {


        /// <summary>
        /// Search WorkplaceType
        /// </summary>
        IEnumerable<WorkPlaceType> SearchWorkplaceType(WorkplaceTypeSearchRequest workplaceTypeSearchRequest, out int rowCount);


        /// <summary>
        /// WorkPlaceType Code validation check
        /// </summary>
        bool IsWorkPlaceTypeCodeExists(WorkPlaceType workPlaceType);
    }
}
