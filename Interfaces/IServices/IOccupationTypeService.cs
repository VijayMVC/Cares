using System.Collections.Generic;
using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Occupation Type Service Interface
    /// </summary>
    public interface IOccupationTypeService
    {
        /// <summary>
        /// Get All Occupation Types
        /// </summary>
        IEnumerable<OccupationType> LoadAll();

        /// <summary>
        /// Delete Occupation Type
        /// </summary>
        void DeleteOccupationType(long occupationTypeId);


        /// <summary>
        /// Search Occupation Type
        /// </summary>
        OccupationTypeSearchRequestResponse SearchOccupationType(OccupationTypeSearchRequest request);

        /// <summary>
        /// Add / Update Occupation Type
        /// </summary>
        OccupationType AddUpdateOccupationType(OccupationType occupationType);
    }
}
