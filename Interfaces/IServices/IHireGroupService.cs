using Cares.Models.RequestModels;
using Cares.Models.ResponseModels;

namespace Cares.Interfaces.IServices
{
    /// <summary>
    /// Hire Group Interface
    /// </summary>
    public interface IHireGroupService
    {
        /// <summary>
        /// Load roups, based on search filters
        /// </summary>
        HireGroupSearchResponse LoadHireGroups(HireGroupSearchRequest tarrifTypeRequest);
        /// <summary>
        /// Load Hire Group Base data
        /// </summary>
        /// <returns></returns>
        HireGroupBaseResponse LoadBaseData();
    }
}
