using Cares.Models.DomainModels;
using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;
using System.Collections.Generic;
namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Nrt Type Service Interface
    /// </summary>
    public interface INrtTypeService
    {
        /// <summary>
        /// Load all Nrt Types
        /// </summary>
        IEnumerable<NrtType> LoadAll();

        /// <summary>
        /// Delete Ntr Type
        /// </summary>
        void DeleteNtrType(long ntrTypeId);

        /// <summary>
        /// Load Base data of NrtType
        /// </summary>
        NrtTypeBaseDataResponse LoadNrtTypeBaseData();

        /// <summary>
        /// Search Nrt Type
        /// </summary>
        NrtTypeSearchRequestResponse SearchNrtType(NrtTypeSearchRequest request);

        /// <summary>
        /// Add / Update Ntr Type
        /// </summary>
        NrtType AddUpdateNtrType(NrtType nrtTypeRequest);
    }
}
